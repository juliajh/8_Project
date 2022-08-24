using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using check;
using UnityEditor.VersionControl;

public class UI_Net : MonoBehaviour
{
    public SpriteRenderer imageSprite;

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

/*    public void OnClickPosRecommendButton()
    {
        PosRecommend();
        
    }*/
/*    private void Start()
    {
        PosRecommend();
    }*/

    /*public async UniTaskVoid PosRecommend()
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

            var data = responseData[0];
            float p_X = float.Parse(data.PosX);
            float p_Y = float.Parse(data.PosY);
            FurnitureManager.Instance.RecommendMake(FurnitureType.Bed, 1, p_X, p_Y, Direction.Front);


            //allPos.RemoveAll();
            *//*for (int i = 0; i < count; ++i)
            {
                var data = responseData[i];
                float.Parse(data.PosX);
                Debug.Log("====="+ float.Parse(data.PosX));
                //Debug.Log("2||||"+data.PosY);
                FurnitureManager.Instance.Make(FurnitureType.Bed, 1,data.PosX,data.PosY,Direction.Front);
            }*//*
        }
    }*/


    // 관련 상품 불러오기
    public void OnClickRelativeLoadButton()
    {
        RelativeLoad();
    }

    public async UniTaskVoid RelativeLoad()
    {
        RelativeRequestData relativeData = new RelativeRequestData
        {
            Title = "여름초록이불 그린컬러이불 여름줄무늬이불 세트 스트"
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
            }
        }
    }


    // 이미지 파일 송신
    public void OnClickSendFileButton()
    {
        SendImageFile();
    }

    public async UniTaskVoid SendImageFile()
    {
        // 이 부분 변경
        Packet_Carrot data = new Packet_Carrot()
        {
            category = "Chair",
            furnitureName = "럭셔리한 파란의자",
            price = "19412",
            title = "파란의자 팝니다.",
            context = "거의 새겁니다."
        };


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



    // 중고거래 게시판 로드
    public void OnClickLoadCarrotButton()
    {
        CarrotLoad();
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
                Debug.Log(data.imgName);
            }
        }
    }
}
