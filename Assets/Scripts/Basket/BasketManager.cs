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

public class BasketManager : MonoBehaviour
{
    public static BasketManager Instance;
   // public GameObject shopContent;
    public List<RecommendResponseData> BasketList = new List<RecommendResponseData>();
    public List<RelativeResponseData> RelativeList = new List<RelativeResponseData>();
    
    //public Transform ParentTransform;
    //public UI_BasketItem Prefab;
    public Action BasketChangeCallback;
    public Action RelativeChangeCallback;

    private void Awake()
    {
        Instance = this;
        BasketLoad();
    }


    private string splitId(String link)
    {
        string id = link.Substring(link.IndexOf("=") + 1).Trim();
        return id;
    }


    public void AddBasket(RecommendResponseData data)
    {
        if (!BasketList.Contains(data))
        {
            BasketList.Add(data);
        }

        BasketChangeCallback?.Invoke();
        OneRelativeLoad();
    }
    
    public void RemoveBasket(RecommendResponseData data)
    {
        BasketList.Remove(data);
        BasketChangeCallback?.Invoke();
        OneRelativeDel(data);
    }

    public void SaveBtnClick()
    {
        BasketSave();
    }

    public async UniTaskVoid BasketSave()
    {
        List<String> saveData = new List<String>(BasketList.Count);

        foreach(RecommendResponseData item in BasketList)
        {
            saveData.Add(splitId(item.Link));
        }

        string jsonData = JsonConvert.SerializeObject(saveData);

        var response = await NetManager.Post<ResponseBasketSavePacket>(new RequestBasketSavePacket(jsonData));

        if (response.Result)
        {
            UnityEngine.Debug.Log("???? ????");
        }
    }


    public async UniTaskVoid BasketLoad()
    {
         var response = await NetManager.Post<ResponseRecommendPacket>(new RequestBasketLoadPacket());

        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                Debug.Log(data.Category);
                Debug.Log(data.Color);
                Debug.Log(data.Title);
                Debug.Log(data.Link);
                Debug.Log(data.Image);
                Debug.Log(data.Brand);
                Debug.Log(data.Price);

                BasketList.Add(data);
            }
        }
        BasketChangeCallback?.Invoke();
        RelativeLoad();
    }

    public async UniTaskVoid RelativeLoad()
    {
        foreach (RecommendResponseData basketItem in BasketList)
        {
            RelativeRequestData relativeData = new RelativeRequestData
            {
                Title = basketItem.Title
            };

            var response = await NetManager.Post<ResponseRelativePacket>(new RequestRelativePacket(relativeData));

            if (response.Result)
            {
                int count = response.Data.Length;

                var responseData = response.Data;
                
                for (int i = 0; i < count; ++i)
                {
                    var data = responseData[i];
                    Debug.Log(data.Title);
                    Debug.Log(data.Price);
                    Debug.Log(data.Link);
                    Debug.Log(data.Image);
                    Debug.Log(data.Relative);
                
                    RelativeList.Add(data);
                }
            }
        }
        RelativeChangeCallback?.Invoke();
    }

    public async UniTaskVoid OneRelativeLoad()
    {
        RelativeRequestData relativeData = new RelativeRequestData
        {
            Title = BasketList[BasketList.Count-1].Title
        };

        var response = await NetManager.Post<ResponseRelativePacket>(new RequestRelativePacket(relativeData));

        
        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                Debug.Log(data.Title);
                Debug.Log(data.Price);
                Debug.Log(data.Link);
                Debug.Log(data.Image);
                Debug.Log(data.Relative);
                RelativeList.Add(data);
            }
        }
        RelativeChangeCallback?.Invoke();
    }
    
    public async UniTaskVoid OneRelativeDel(RecommendResponseData deldata)
    {
        RelativeList.RemoveAll(d => d.Relative == deldata.Title);
        
        RelativeChangeCallback?.Invoke();
    }
    
    public void OnClickBasketAllDeleteButton()
    {
        BasketDelete();
    }

    public async UniTaskVoid BasketDelete()
    {
        var response = await NetManager.Post<ResponseBasketDeletePacket>(new RequestBasketDeletePacket());
        BasketList.Clear();
        if (response.Result)
        {
            Debug.Log("?????? ???? ???");
        }

        BasketChangeCallback?.Invoke();
        RelativeList.Clear();
        RelativeChangeCallback?.Invoke();
        
    }

}
