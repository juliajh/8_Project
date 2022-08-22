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

public class CarrotManager : MonoBehaviour
{
    public static CarrotManager Instance;
    public List<RecommendResponseData> CarrotList = new List<RecommendResponseData>();


    private void Awake()
    {
        Instance = this;
    }

    
    private void Start()
    {
        //Load();
        CarrotLoad();
    }

    public async UniTaskVoid CarrotSave()
    {
        List<String> saveData = new List<String>(CarrotList.Count);

        foreach (RecommendResponseData item in CarrotList)
        {
            saveData.Add(item.Title);
        }

        string jsonData = JsonConvert.SerializeObject(saveData);

        var response = await NetManager.Post<ResponseBasketSavePacket>(new RequestBasketSavePacket(jsonData));

        if (response.Result)
        {
            UnityEngine.Debug.Log("���� ����");
        }
    }


    public async UniTaskVoid CarrotLoad()
    {
        //�����ϱ� 
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

                CarrotList.Add(data);
            }
        }
    }

    /*
    public void AddBasket(RecommendResponseData data)
    {
        if (!BasketList.Contains(data))
        {
            BasketList.Add(data);
        }
        CountBasket();

    }
    
    public void RemoveBasket(RecommendResponseData data)
    {
        BasketList.Remove(data);
        CountBasket();
    }

    public void SaveBtnClick()
    {
        BasketSave();
    }



    public void OnClickBasketDeleteButton()
    {
        BasketDelete();
    }

    public async UniTaskVoid BasketDelete()
    {
        var response = await NetManager.Post<ResponseBasketDeletePacket>(new RequestBasketDeletePacket());
        BasketList.Clear();
        CountBasket();
        if (response.Result)
        {
            Debug.Log("��ٱ��� ���� �Ϸ�");
        }
    }

    */

}
