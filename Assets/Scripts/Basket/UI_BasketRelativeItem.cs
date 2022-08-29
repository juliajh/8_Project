using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_BasketRelativeItem : MonoBehaviour
{
    private RelativeResponseData m_Data;

    public Text m_Title;
    public Text m_Price;
    public Text m_Relative;
    public RawImage m_IconImage;
    
    public void Init(RelativeResponseData data)
    {
        m_Data = data;

        Set();
    }

    private void Set()
    {
        m_Title.text = m_Data.Title;
        m_Price.text = m_Data.Price;
        m_Relative.text = '"' + m_Data.Relative.Substring(0,7) +"..."+'"'+ "를 본 사용자가 가장 많이 본 상품입니다.";
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
