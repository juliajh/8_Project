using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;

public class UI_BasketItem : MonoBehaviour
{
    private RecommendResponseData m_Data;

    public RawImage m_IconImage;
    public TextMeshProUGUI m_NameText;
    public TextMeshProUGUI m_PriceText;

    public void Init(RecommendResponseData data)
    {
        m_Data = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Data.Title;
        m_PriceText.text = $"{Int32.Parse(m_Data.Price):N0}₩";

        StartCoroutine(DownloadImage(m_Data.Image));
    }

    IEnumerator DownloadImage(string MediaUrl)
    {
        string url = MediaUrl;//.Replace("https://", "http://");
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
    
    public void OnClickBuyButton()
    {
        Application.OpenURL(m_Data.Link);
    }

    public void OnClickRemoveButton()
    {
        BasketManager.Instance.RemoveBasket(m_Data);
        UI_Basket.Instance.Refresh();

    }

}
