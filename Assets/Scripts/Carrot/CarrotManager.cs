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
    public List<Packet_Carrot> CarrotList = new List<Packet_Carrot>();
    public SpriteRenderer imageSprite;

    public Action OnChangeCallback;

    private void Awake()
    {
        Instance = this;
    }

    
    private void Start()
    {
        //Load();
        //CarrotLoad();
    }

    
    public void RemoveCarrot(Packet_Carrot data)
    {
        CarrotList.Remove(data);
    }

    /*
    public async UniTaskVoid CarrotLoad()
    {
        //수정하기 
        var response = await NetManager.Post<Packet_Carrot>(new Packet_Carrot());

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
            Debug.Log("장바구니 삭제 완료");
        }
    }

    */

}
