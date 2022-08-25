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


// 게시판 삭제
// 요청 패킷 (index만 넘김)
public class RequestCarrotDeletePacket : IRequestPacket
{
    public string index { get; private set; }

    public RequestCarrotDeletePacket(string index) : base("/DeleteUsed")
    {
        this.index = index;
    }
}

// 수신 패킷
// 성공여부만 저장
public class ResponseCarrotDeletePacket : ResponsePacket
{
}

// update list delete write