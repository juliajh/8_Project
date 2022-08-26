using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using check;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

public class UI_CarrotWrite : MonoBehaviour
{
    private CarrotResponseData m_Data;

    public RawImage m_RawImage;
    public SpriteRenderer m_Rawimage1;

    public Image m_Image;
    public InputField m_FurnitureNameText;
    public InputField m_PriceText;
    public InputField m_TitleText;
    public InputField m_ContextText;
    public Dropdown m_CategoryText;
    public static UI_CarrotWrite Instance;
    public String image_Name;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Back()
    {
        Close();
        UI_Carrot.Instance.Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        m_RawImage.gameObject.SetActive(false);
        m_Image.gameObject.SetActive(true);
    }

    public void Close()
    {
        Clear();
        gameObject.SetActive(false);
    }

    //Edit시 필요
    public void Init(CarrotResponseData data)
    {
        m_Data = data;
        Set();
    }

    private void Set()
    {
        m_RawImage.gameObject.SetActive(true);
        m_Image.gameObject.SetActive(false);

        if (m_Data == null)
        {
            return;
        }

        int index = m_CategoryText.options.FindIndex((i) => { return i.text.Equals(m_Data.category); });

        m_CategoryText.value = index;
        m_FurnitureNameText.text = m_Data.furnitureName;
        m_TitleText.text = m_Data.title;
        m_ContextText.text = m_Data.context;
        m_PriceText.text = m_Data.price;

        StartCoroutine(GetTexture(m_RawImage, m_Data.imgName));
    }

    public void AddCarrot()
    {
        SaveCarrot();
    }

    public async UniTaskVoid SaveCarrot()
    {
        CarrotResponseData data = new CarrotResponseData()
        {
            category = m_CategoryText.options[m_CategoryText.value].text,
            furnitureName = m_FurnitureNameText.text.ToString(),
            price = m_PriceText.text.ToString(),
            title = m_TitleText.text.ToString(),
            context = m_ContextText.text.ToString(),
        };
        var response = await ImageUploader
                .Initialize()
                .SetTexture(m_Image.sprite.texture)
                .SetFieldName("file")
                .SetFileName("file")
                .SetType(ImageType.JPG)
                .SetCategory(data.category) // 카테고리
                .SetFurnitureName(data.furnitureName) // 가구명 (상품명이므로 아무거나)
                .SetPrice(data.price) // 가격
                .SetTitle(data.title) // 게시글 제목
                .SetContext(data.context) // 게시글 내용
                .SetUploaderId() // DeviceId (자동으로 불러옴)
                .SetUrl("/InsertUsedBoard")
                .OnError(error => Debug.Log(error))
                .OnComplete(text => Debug.Log(text))
                .StartUploading();

        CarrotManager.Instance.CarrotList.Add(data);
        Close();
        UI_Carrot.Instance.Open();
    }

    /*
    IEnumerator GetTexture(RawImage img, string image_name)
    {
        var url = "http://www.mongilmongilgames.com/image/" + image_name;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            m_Image.texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

        }
    }
    */

    private void Clear()
    {
        m_FurnitureNameText.text = "";
        m_PriceText.text = "";
        m_TitleText.text = "";
        m_ContextText.text = "";
        m_CategoryText.value = 0;
    }
    Texture2D convertForTexture;
    public IEnumerator GetTexture(RawImage img, string image_name)
    {
        var url = "http://www.mongilmongilgames.com/image/" + image_name;
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            convertForTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Rect rect = new Rect(0, 0, convertForTexture.width, convertForTexture.height);
            img.GetComponent<SpriteRenderer>().sprite = Sprite.Create(convertForTexture, rect, new Vector2(0.5f, 0.5f));

        }
    }
}
