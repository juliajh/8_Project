using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;

public class UI_CarrotItem : MonoBehaviour
{
    private RecommendResponseData m_Data;

    public RawImage m_IconImage;

    public TextMeshProUGUI m_CategoryText;
    public TextMeshProUGUI m_TitleText;
    public TextMeshProUGUI m_DescribeText;
    public TextMeshProUGUI m_PriceText;

    public void Init(RecommendResponseData data)
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

        m_CategoryText.text = m_Data.Category;
        m_TitleText.text = m_Data.Title;
        //m_DescribeText.text = m_Data.Describe;
        m_PriceText.text = $"{Int32.Parse(m_Data.Price):N0}₩";

        StartCoroutine(DownloadImage(m_Data.Image));
    }

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
    

}
