using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using TMPro;
using System;
using check;

public class CarrotManager : MonoBehaviour
{
    public static CarrotManager Instance;
    public List<CarrotResponseData> CarrotList = new List<CarrotResponseData>();


    public List<RawImage> CarrotImage = new List<RawImage>();
    public SpriteRenderer imageSprite;

    public Action OnChangeCallback;

    private void Awake()
    {
        Instance = this;
    }

    
    private void Start()
    {
        CarrotLoad();
    }

    
    public void RemoveCarrot(CarrotResponseData data)
    {
        CarrotList.Remove(data);
    }

    public async UniTaskVoid CarrotLoad()
    {
        var response = await NetManager.Post<ResponseCarrotListPacket>(new RequestCarrotListPacket());

        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                Debug.Log(data.category);
                Debug.Log(data.furnitureName);
                Debug.Log(data.price);
                Debug.Log(data.title);
                Debug.Log(data.context);
                Debug.Log(data.uploaderId);
                Debug.Log(data.index);

                CarrotList.Add(data);
            }
        }
    }

    public IEnumerator GetTexture(RawImage img, string image_name)
    {
        var url = "http://www.mongilmongilgames.com/image/" + image_name;
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
