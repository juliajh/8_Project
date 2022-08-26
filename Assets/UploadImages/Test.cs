using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using check;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Networking;

using FrostweepGames.Plugins.WebGLFileBrowser;

/*using WebGLFileUploader;
using WebGLFileUploaderExample;*/
//using AnotherFileBrowser.Windows;


public class Test : MonoBehaviour
{
    public SpriteRenderer imageSprite;
    public string serverUrl;


    // 찾아보기 explorer
    public RawImage showImage;

    public void StartBtn()
    {
        ImageUploader
            .Initialize()
            .SetTexture(imageSprite.sprite.texture)
            //.SetTexture(image.texture)
            .SetFieldName("file")
            .SetFileName("file")
            .SetType(ImageType.JPG)
            .OnError(error => Debug.Log(error))
            .OnComplete(text => Debug.Log(text))
            .Upload();

        showImage.texture = imageSprite.sprite.texture;

        /* ImageUploader
             .Initialize()
             .SetUrl(serverUrl)
             .SetTexture(imageSprite.sprite.texture)
             .SetFieldName("file")
             .Upload();*/
    }


    public void RecieveImg() 
    {
        StartCoroutine(GetTexture(showImage));
    }


    Sprite spirit;
    Texture2D t;
    public IEnumerator GetTexture(RawImage img)
    {
        var url = "http://www.skillagit.com/data/product/1592228454.png";
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            t=((DownloadHandlerTexture)www.downloadHandler).texture;
            Rect rect = new Rect(0, 0, t.width, t.height);
            img.GetComponent<SpriteRenderer>().sprite = Sprite.Create(t, rect, new Vector2(0.5f, 0.5f));
           
            


           
        }
    }




    /*    public void OpenExplorer()
        {
            path = EditorUtility.OpenFilePanel("Oberwrite with JPG", "", "jpg");

            GetImage();
        }


        void GetImage()
        {
            if (path != null)
            {
                UpdateImage();
            }
        }
        //.RawImage sprite1;
        void UpdateImage()
        {
            WWW www = new WWW("file://" + path);

            Rect rect = new Rect(0, 0, www.texture.width, www.texture.height);
            showImage.GetComponent<SpriteRenderer>().sprite = Sprite.Create(www.texture, rect, new Vector2(0.5f, 0.5f));

            //showImage.sprite.texture = www.texture;
        }*/

}
