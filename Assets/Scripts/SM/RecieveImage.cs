using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


using Cysharp.Threading.Tasks;
using UniRx;
using Newtonsoft.Json;
using TMPro;
using System;
using check;


public class RecieveImage : MonoBehaviour
{
    public RawImage image;
    public TextMeshProUGUI m_CategoryText;
    public TextMeshProUGUI m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public TextMeshProUGUI m_TitleText;
    public TextMeshProUGUI m_ContextText;


    private CarrotResponseData m_Data;
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
        //StartCoroutine(GetTexture(image, m_Data.imgName));
    }
    public void DownloadImage() 
    {
        StartCoroutine(GetTexture(image));
    }

    IEnumerator GetTexture(RawImage img)
    {
        var url = "https://cdn.searchenginejournal.com/wp-content/uploads/2022/04/reverse-image-search-627b7e49986b0-sej-760x400.png";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            CarrotImage.Add(img);
            CarrotImage[0].texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
        }
    }






    public static CarrotManager Instance;
    public List<CarrotResponseData> CarrotList = new List<CarrotResponseData>();


    public List<RawImage> CarrotImage = new List<RawImage>();
    public SpriteRenderer imageSprite;

    public Action OnChangeCallback;
    public void RemoveCarrot(CarrotResponseData data)
    {
        CarrotList.Remove(data);
    }

    public async UniTaskVoid CarrotLoad()
    {
        var response = await NetManager.Post<ResponseCarrotListPacket>(new RequestCarrotListPacket());

        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;

            DownloadImage();

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                Debug.Log(data.category);
                Debug.Log(data.furnitureName);
                Debug.Log(data.price);
                Debug.Log(data.title);
                Debug.Log(data.context);
                Debug.Log(data.uploaderId);
                Debug.Log(data.index);
                Debug.Log(data.imgName);

                CarrotList.Add(data);
            }
        }
    }
}
