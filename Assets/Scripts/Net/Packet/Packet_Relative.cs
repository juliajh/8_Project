using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RelativeRequestData
{
    public string Title;
}

public class RelativeResponseData
{
    public string Link;
    public string Image;
    public string Title;
    public string Price;
    public string Relative;
}


public class RequestRelativePacket : IRequestPacket
{
    public RelativeRequestData relativeRequestData { get; private set; }

    public RequestRelativePacket(RelativeRequestData relativeRequestData) : base("/LoadRelative")
    {
        this.relativeRequestData = relativeRequestData;
    }
}


public class ResponseRelativePacket : ResponsePacket
{
    public RelativeResponseData[] Data { get; private set; }
}