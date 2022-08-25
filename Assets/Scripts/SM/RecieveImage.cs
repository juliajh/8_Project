using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class RecieveImage : MonoBehaviour
{
    public RawImage image;



    public void DownloadImage() 
    {
        StartCoroutine(GetTexture(image));
    }

    IEnumerator GetTexture(RawImage img)
    {
        var url = "http://www.mongilmongilgames.com/image/" + $".{1}jpg";
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
}
