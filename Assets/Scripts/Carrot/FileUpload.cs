using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using WebGLFileUploader;

public class FileUpload : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("WebGLFileUploadManager.getOS: " + WebGLFileUploadManager.getOS);
        Debug.Log("WebGLFileUploadManager.isMOBILE: " + WebGLFileUploadManager.IsMOBILE);
        Debug.Log("WebGLFileUploadManager.getUserAgent: " + WebGLFileUploadManager.GetUserAgent);

        WebGLFileUploadManager.SetDebug(true);
        if (
#if UNITY_WEBGL && !UNITY_EDITOR
                    WebGLFileUploadManager.IsMOBILE 
#else
                    Application.isMobilePlatform
#endif
            )
        {
            WebGLFileUploadManager.Show(false);
            WebGLFileUploadManager.SetDescription("Select image files (.png|.jpg|.gif)");

        }
        else
        {
            WebGLFileUploadManager.Show(true);
            WebGLFileUploadManager.SetDescription("Drop image files (.png|.jpg|.gif) here");
        }
        WebGLFileUploadManager.SetImageEncodeSetting(true);
        WebGLFileUploadManager.SetAllowedFileName("\\.(png|jpe?g|gif)$");
        WebGLFileUploadManager.SetImageShrinkingSize(1280, 960);
        WebGLFileUploadManager.onFileUploaded += OnFileUploaded;
    }

    private void OnFileUploaded(UploadedFileInfo[] result)
    {
        if (result.Length == 0)
        {
            Debug.Log("File upload Error!");
        }
        else
        {
            Debug.Log("File upload success! (result.Length: " + result.Length + ")");
        }

        foreach (UploadedFileInfo file in result)
        {
            if (file.isSuccess)
            {
                Debug.Log("file.filePath: " + file.filePath + " exists:" + File.Exists(file.filePath));

                Texture2D texture = new Texture2D(2, 2);
                byte[] byteArray = File.ReadAllBytes(file.filePath);
                texture.LoadImage(byteArray);
                gameObject.GetComponent<Renderer>().material.mainTexture = texture;

                Debug.Log("File.ReadAllBytes:byte[].Length: " + byteArray.Length);

                break;
            }
        }
    }

    public void OnSwitchButtonOverlayStateButtonClick()
    {
        WebGLFileUploadManager.Show(false, !WebGLFileUploadManager.IsOverlay);
    }
}
