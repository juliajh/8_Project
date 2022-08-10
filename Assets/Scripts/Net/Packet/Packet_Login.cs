using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RequestLoginPacket : IRequestPacket
{
    public RequestLoginPacket() : base("/Login")
    {

    }
}


public class ResponseLoginPacket : ResponsePacket
{
    public string Map { get; private set; }
}