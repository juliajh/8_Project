using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using check;

using FrostweepGames.Plugins.WebGLFileBrowser;

/*using WebGLFileUploader;
using WebGLFileUploaderExample;*/
//using AnotherFileBrowser.Windows;


public class Test : MonoBehaviour
{
    public SpriteRenderer imageSprite;
    public string serverUrl;


    // 찾아보기 explorer
    public SpriteRenderer showImage;

    public void StartBtn()
    {
        ImageUploader
            .Initialize()
            .SetUrl(serverUrl)
            .SetTexture(imageSprite.sprite.texture)
            //.SetTexture(image.texture)
            .SetFieldName("file")
            .SetFileName("file")
            .SetType(ImageType.JPG)
            .OnError(error => Debug.Log(error))
            .OnComplete(text => Debug.Log(text))
            .Upload();

        /* ImageUploader
             .Initialize()
             .SetUrl(serverUrl)
             .SetTexture(imageSprite.sprite.texture)
             .SetFieldName("file")
             .Upload();*/
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
