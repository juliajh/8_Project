using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetTest : MonoBehaviour
{
    public RawImage img;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetTexture("1.jpg", img));
    }


    // 이미지 파일명, 이미지 저장할 게임 오브젝트
    IEnumerator GetTexture(string imgName, RawImage img)
    {
        var url = "http://www.mongilmongilgames.com/image/" + imgName;
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
