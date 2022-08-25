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


// �Խ��� �ε� (��ü �� �ҷ�����)
// ��û ��Ŷ (�ƹ��͵� �� ����)
public class RequestCarrotListPacket : IRequestPacket
{
    public RequestCarrotListPacket() : base("/LoadUsed")
    {
    }
}

// ���� ��Ŷ
// ����Ʈ�� �Խñ� �޾ƿ�
public class ResponseCarrotListPacket : ResponsePacket
{
    public CarrotResponseData[] Data { get; private set; }
}


// �Խ��� ����
// ��û ��Ŷ (index�� �ѱ�)
public class RequestCarrotDeletePacket : IRequestPacket
{
    public string index { get; private set; }

    public RequestCarrotDeletePacket(string index) : base("/DeleteUsed")
    {
        this.index = index;
    }
}

// ���� ��Ŷ
// �������θ� ����
public class ResponseCarrotDeletePacket : ResponsePacket
{
}

// update list delete write