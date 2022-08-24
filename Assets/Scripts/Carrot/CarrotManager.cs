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
    private void Awake()
    {
        Instance = this;
    }

    
    private void Start()
    {
        //Load();
        //CarrotLoad();
    }

    public void OnClickSaveButton()
    {
        CarrotSave();
    }

    public async UniTaskVoid CarrotSave()
    {
        foreach(Packet_Carrot data in CarrotList)
        {
            ImageUploader
                .Initialize()
                .SetTexture(imageSprite.sprite.texture)
                .SetFieldName("file")
                .SetFileName("file")
                .SetType(ImageType.JPG)
                .SetCategory(data.category) // 카테고리
                .SetFurnitureName(data.furnitureName) // 가구명 (상품명이므로 아무거나)
                .SetPrice(data.price) // 가격
                .SetTitle(data.title) // 게시글 제목
                .SetContext(data.context) // 게시글 내용
                .SetUploaderId() // DeviceId (자동으로 불러옴)
                .OnError(error => Debug.Log(error))
                .OnComplete(text => Debug.Log(text))
                .Upload();
        }
        
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
            Debug.Log("장바구니 삭제 완료");
        }
    }

    */

}
