using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestRecommendPacket : IRequestPacket
{
    public RequestRecommendPacket() : base("/Recommend")
    {
    }
}

public class ResponseRecommendPacket : ResponsePacket
{
}