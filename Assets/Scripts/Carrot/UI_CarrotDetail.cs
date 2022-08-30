using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_CarrotDetail : MonoBehaviour
{
    private CarrotResponseData m_Data;

    public RawImage m_RawImage;
    public Text m_CategoryText;
    public Text m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public Text m_TitleText;
    public Text m_ContextText;
    public Button DeleteBtn;
    public Button EditBtn;

    public static UI_CarrotDetail Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(CarrotResponseData data)
    {
        m_Data = data;
        DeleteBtn.gameObject.SetActive(false);
        EditBtn.gameObject.SetActive(false);
        Set();
    }

    private void Set()
    {

        if (m_Data == null)
        {
            return;
        }

        m_CategoryText.text = m_Data.category;
        m_FurnitureNameText.text = m_Data.furnitureName;
        m_TitleText.text = m_Data.title;
        m_ContextText.text = m_Data.context;
        m_PriceText.text = m_Data.price;

        if(m_Data.uploaderId== UnityEngine.SystemInfo.deviceUniqueIdentifier)
        {
            DeleteBtn.gameObject.SetActive(true);
            EditBtn.gameObject.SetActive(true);
        }

        StartCoroutine(GetTexture(m_RawImage, m_Data.imgName));

    }
    
    IEnumerator GetTexture(RawImage img, string image_name)
    {
        string url = $"{NetDefine.NET_SERVER_ADDR}/proxy/http://www.mongilmongilgames.com/image/{image_name}";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
       
    }

    public void Open()
    {
        m_Data = null;
        gameObject.SetActive(true);
    }

    public void Back()
    {
        Close();
        UI_Carrot.Instance.Open();
    }

    public void Close()
    {
        gameObject.SetActive(false);    
    }

    public void Delete()
    {
        CarrotManager.Instance.RemoveCarrot(m_Data);
        Close();
        UI_Carrot.Instance.Open();
    }

    public void Edit()
    {
        Close();
        UI_CarrotWrite.Instance.Open();
        UI_CarrotWrite.Instance.Init(m_Data);
    }


}
