using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RequestSavePacket : IRequestPacket
{
    public RequestSavePacket() : base("/save")
    {
    }
}

public class ResponseSavePacket : ResponsePacket
{
}