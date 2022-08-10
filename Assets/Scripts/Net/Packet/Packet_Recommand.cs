using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecommendData
{
    public int Index;
    public string FurnitureType;
    public string ColorType;
}


public class RequestRecommendPacket : IRequestPacket
{
    public RecommendData RecommendData { get; private set; }
    
    public RequestRecommendPacket(RecommendData recommendData) : base("/Recommend")
    {
        this.RecommendData = recommendData;
    }
}

public class ResponseRecommendPacket : ResponsePacket
{
}