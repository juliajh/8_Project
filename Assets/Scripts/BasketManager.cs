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
    public GameObject shopContent;
    public TextMeshProUGUI countText;
    public List<RecommendResponseData> BasketList = new List<RecommendResponseData>();
    public Transform ParentTransform;
    public UI_BasketItem Prefab;


    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        //Load();
        CountBasket();
        BasketLoad();
    }

    private string splitId(String link)
    {
        string id = link.Substring(link.IndexOf("=") + 1).Trim();
        return id;
    }

    private void CountBasket()
    {
        countText.text = BasketList.Count.ToString();
    }

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
        var response = await NetManager.Post<ResponseBasketLoadPacket>(new RequestBasketLoadPacket());

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

                Make(data);
            }
        }
    }



    public void Make(BasketResponseData data)
    {
        var newItem = Instantiate<UI_BasketItem>(Prefab);
        newItem.transform.SetParent(ParentTransform);
        newItem.transform.localScale = new Vector3(1, 1, 1);
        newItem.transform.position = new Vector3(0,0, 0);
        newItem.gameObject.SetActive(true);

        /*
        newItem.m_NameText.text = data.Title;
        newItem.m_PriceText.text = data.Price;
        */


    }


}
