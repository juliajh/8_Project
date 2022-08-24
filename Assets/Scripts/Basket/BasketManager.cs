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
    public Transform ParentTransform;
    public UI_BasketItem Prefab;
    public Action OnChangeCallback;

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

        OnChangeCallback?.Invoke();
    }
    
    public void RemoveBasket(RecommendResponseData data)
    {
        BasketList.Remove(data);

        OnChangeCallback?.Invoke();
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
            UnityEngine.Debug.Log("저장 성공");
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
        OnChangeCallback?.Invoke();

    }

    public void OnClickBasketDeleteButton()
    {
        BasketDelete();
    }

    public async UniTaskVoid BasketDelete()
    {
        var response = await NetManager.Post<ResponseBasketDeletePacket>(new RequestBasketDeletePacket());
        BasketList.Clear();
        if (response.Result)
        {
            Debug.Log("장바구니 삭제 완료");
        }
    }

}
