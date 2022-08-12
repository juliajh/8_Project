using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecommendRequestData
{
    public string FurnitureType;
    public string ColorType;
}

public class RecommendResponseData
{
    public string Category;
    public string Color;
    public string Title;
    public string Link;
    public string Image;
    public string Brand;
    public string Price;
}

public class RequestRecommendPacket : IRequestPacket
{
    public RecommendRequestData RecommendRequestData { get; private set; }
    
    public RequestRecommendPacket(RecommendRequestData recommendRequestData) : base("/Recommend")
    {
        this.RecommendRequestData = recommendRequestData;
    }
}

public class RequestRecommendRandomPacket: IRequestPacket
{
    public RequestRecommendRandomPacket() : base("/RecommendRandom")
    {
    }
}


public class ResponseRecommendPacket : ResponsePacket
{
    public RecommendResponseData[] Data { get; private set; }

}