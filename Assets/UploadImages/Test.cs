using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Test : MonoBehaviour
{
    public SpriteRenderer imageSprite;
    public string serverUrl;


    // 찾아보기 explorer
    string path;
    public SpriteRenderer image;

    public void StartBtn()
    {
        ImageUploader
            .Initialize()
            .SetTexture(imageSprite.sprite.texture)
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


    public void OpenExplorer() 
    {
       // path = EditorUtility.OpenFilePanel("Oberwrite with JPG", "", "jpg");

        //GetImage();
    }


    void GetImage() 
    {
        if (path != null) 
        {
            //UpdateImage();
        }
    }

   /* void UpdateImage()
    {
        WWW www = new WWW("file://" + path);
        Rect rect = new Rect(0, 0, image.width, image.height);
        image.sprite = Sprite.Create(www.texture, rect, new Vector2(0.5f, 0.5f));
    }*/

}
