using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PosRequestData
{
    public string FurnitureType;
    public string ColorType;
}

public class PosResponseData
{
    public string PosX;
    public string PosY;
    public string name;
    public string vaule;
    public string fur;
    public string color;
}


public class RequestPosPacket : IRequestPacket
{
    public PosRequestData PosRequestData { get; private set; }

    public RequestPosPacket(PosRequestData posRequestData) : base("/RecommendPos")
    {
        this.PosRequestData = posRequestData;
    }
}


public class ResponsePosPacket : ResponsePacket
{
    public PosResponseData[] Data { get; private set; }

}