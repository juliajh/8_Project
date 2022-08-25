using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet_Carrot
{
    public int id;
    public int userId;
    public string category;
    public string furnitureName;
    public string price;
    public string title;
    public string context;
}


public class CarrotResponseData
{
    public string category;
    public string furnitureName;
    public string price;
    public string title;
    public string context;
    public string uploaderId;
    public string index;
    public string imgName;
}


// 게시판 로드 (전체 글 불러오기)
// 요청 패킷 (아무것도 안 보냄)
public class RequestCarrotListPacket : IRequestPacket
{
    public RequestCarrotListPacket() : base("/LoadUsed")
    {
    }
}

// 수신 패킷
// 리스트로 게시글 받아옴
public class ResponseCarrotListPacket : ResponsePacket
{
    public CarrotResponseData[] Data { get; private set; }
}


// update list delete write