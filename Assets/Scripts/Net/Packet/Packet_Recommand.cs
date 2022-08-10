using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecommendRequestData
{
    public int Index;
    public string FurnitureType;
    public string ColorType;
}

public class RecommendResponseData
{
    public string ImageUrl; // 가구 이미지 주소
    public string Name;     // 가구
}

public class RequestRecommendPacket : IRequestPacket
{
    public RecommendRequestData RecommendRequestData { get; private set; }
    
    public RequestRecommendPacket(RecommendRequestData recommendRequestData) : base("/Recommend")
    {
        this.RecommendRequestData = recommendRequestData;
    }
}

public class ResponseRecommendPacket : ResponsePacket
{
    public RecommendResponseData[] Data { get; private set; }

}