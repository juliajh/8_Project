using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RequestSavePacket : IRequestPacket
{
    public string Map { get; private set; }
    
    public RequestSavePacket(string map) : base("/Save")
    {
        this.Map = map;
    }
}

public class ResponseSavePacket : ResponsePacket
{
}