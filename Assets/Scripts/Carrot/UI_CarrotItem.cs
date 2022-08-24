using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;

public class UI_CarrotItem : MonoBehaviour
{
    private Packet_Carrot m_Data;

    public RawImage m_IconImage;

    public TextMeshProUGUI m_CategoryText;
    public TextMeshProUGUI m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public TextMeshProUGUI m_TitleText;  
    public TextMeshProUGUI m_ContextText;


    public void Init(Packet_Carrot data)
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

        //StartCoroutine(DownloadImage(m_Data.Image));
    }

    /*
    IEnumerator DownloadImage(string MediaUrl)
    {
        string url = MediaUrl.Replace("https://", "http://");
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

}
