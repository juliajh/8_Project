using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class UI_Net : MonoBehaviour
{
    /*
    public void OnClickLoginButton()
    {
        Login();
    }
    public async UniTaskVoid Login()
    {
        var response = await NetManager.Post<ResponseLoginPacket>(new RequestLoginPacket());

        if (response.Result)
        {
            UnityEngine.Debug.Log(response.Result);
            UnityEngine.Debug.Log(response.Map);
        }
        
    }

    */
    public void OnClickSaveButton()
    {
        //Save();

        FurnitureManager.Instance.Save();
    }

    public async UniTaskVoid Save()
    {
        var response = await NetManager.Post<ResponseSavePacket>(new RequestSavePacket("{id: 134234}"));

        if (response.Result)
        {
            UnityEngine.Debug.Log("저장 성공");
        }
    }

    public void OnClickRecommendButton()
    {
       Recommend();
    }

    public  async UniTaskVoid Recommend()
    {
        // 가구 타입
        // 가구 아이디
        // 가구 색상

        RecommendRequestData recommendRequestData = new RecommendRequestData
        {
            FurnitureType = FurnitureType.Chair.ToString(),
            ColorType = ColorType.Blue.ToString()
        };
        
        var response = await NetManager.Post<ResponseRecommendPacket>(new RequestRecommendPacket(recommendRequestData));

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
            }
        }
    }


    public void OnClickRandomRecommendButton()
    {
        RandomRecommend();
    }

    public async UniTaskVoid RandomRecommend()
    {
        // 가구 타입
        // 가구 아이디
        // 가구 색상


        var response = await NetManager.Post<ResponseRecommendPacket>(new RequestRecommendRandomPacket());

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
            }
        }
    }


    // 가구 위치값 추천
    // furnitureType, colorType을 보내고
    // 추천 위치인 pos_x, pos_y값을 받는다

    public void OnClickPosRecommendButton()
    {
        PosRecommend();
    }

    public async UniTaskVoid PosRecommend()
    {
        // 가구 타입
        // 가구 아이디
        // 가구 색상
        PosRequestData posRequestData = new PosRequestData
        {
            FurnitureType = FurnitureType.Bed.ToString(),
            ColorType = ColorType.Blue.ToString()
        };

        var response = await NetManager.Post<ResponsePosPacket>(new RequestPosPacket(posRequestData));

        if (response.Result)
        {
            int count = response.Data.Length;

            var responseData = response.Data;

            for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                Debug.Log(data.PosX);
                Debug.Log(data.PosY);
            }
        }
    }


    // 장바구니 저장
    public void OnClickBasketSaveButton()
    {
        BasketSave();
    }

    public async UniTaskVoid BasketSave()
    {
        List<String> saveData = new List<String>(3);

        String tmp = new String("83963435437");
        String tmp1 = new String("31793306187");
        String tmp2 = new String("32942017315");
        saveData.Add(tmp);
        saveData.Add(tmp1);
        saveData.Add(tmp2);

        string jsonData = JsonConvert.SerializeObject(saveData);

        var response = await NetManager.Post<ResponseBasketSavePacket>(new RequestBasketSavePacket(jsonData));

        if (response.Result)
        {
            UnityEngine.Debug.Log("저장 성공");
        }
    }


    // 장바구니 로드

    public void OnClickBasketLoadButton()
    {
        BasketLoad();
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
            }
        }
    }


    // 장바구니 전체 삭제
    public void OnClickBasketDeleteButton()
    {
        BasketDelete();
    }

    public async UniTaskVoid BasketDelete()
    {
        var response = await NetManager.Post<ResponseBasketDeletePacket>(new RequestBasketDeletePacket());

        if (response.Result)
        {
            Debug.Log("장바구니 삭제 완료");
        }
    }

}
