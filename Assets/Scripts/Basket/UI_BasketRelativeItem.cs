using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UI_BasketRelativeItem : MonoBehaviour
{
    private RelativeResponseData m_Data;
    
    public RawImage m_IconImage;
    
    public void Init(RelativeResponseData data)
    {
        m_Data = data;

        Set();
    }

    private void Set()
    {
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
