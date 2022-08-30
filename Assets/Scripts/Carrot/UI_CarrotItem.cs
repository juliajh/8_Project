using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;

public class UI_CarrotItem : MonoBehaviour
{
    private CarrotResponseData m_Data;

    //public List<RawImage> m_imageList = new List<RawImage>();
    public RawImage m_Image;
    public TextMeshProUGUI m_CategoryText;
    public TextMeshProUGUI m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public TextMeshProUGUI m_TitleText;  
    public TextMeshProUGUI m_ContextText;


    public void Init(CarrotResponseData data)
    {
        m_Data = data;

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
        StartCoroutine(GetTexture(m_Image,m_Data.imgName));
    }

    IEnumerator GetTexture(RawImage img, string image_name)
    {

        string url = $"{NetDefine.NET_SERVER_ADDR}/proxy/http://www.mongilmongilgames.com/image/{image_name}";

        Debug.Log("url=="+url);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            yield return new WaitForSeconds(1f);
            //StartCoroutine(GetTexture(m_Image,m_Data.imgName));
            Debug.Log(www.error);
        }
        else
        {
            img.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            
        }
    }

    /*
    IEnumerator DownloadImage(string MediaUrl)
    {
        string url = $"{NetDefine.NET_SERVER_ADDR}/proxy/{MediaUrl}";
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            m_IconImage.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
        }
    } 
    */

    public void itemClick()
    {
        UI_CarrotDetail.Instance.Open();
        UI_CarrotDetail.Instance.Init(m_Data);
        
    }
}
