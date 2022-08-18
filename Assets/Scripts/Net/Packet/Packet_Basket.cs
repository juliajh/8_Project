using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BasketResponseData
{
    public string Category;
    public string Color;
    public string Title;
    public string Link;
    public string Image;
    public string Brand;
    public string Price;
}


// ��ٱ��� �ҷ����� ��û ��Ŷ
// deviceId�� ������ ��
public class RequestBasketLoadPacket : IRequestPacket
{
    public RequestBasketLoadPacket() : base("/LoadBasket")
    {
    }
}

// ��ٱ��� �ҷ����� ���� ��Ŷ
// ��ǰ �������� �޾ƿ´�
public class ResponseBasketLoadPacket : ResponsePacket
{
    public BasketResponseData[] Data { get; private set; }
}



// ��ٱ��� �����ϴ� ��û ��Ŷ
// ������ ��ǰ�� Link ���ڿ��� ���� �����ϴ� id�� ����Ʈ�� string���·� ������
public class RequestBasketSavePacket : IRequestPacket
{
    public string Product { get; private set; }

    public RequestBasketSavePacket(string product) : base("/UpdateBasket")
    {
        this.Product = product;
    }
}

// ��ٱ��� �����ϴ� ���� ��Ŷ
public class ResponseBasketSavePacket : ResponsePacket
{
}



// ��ٱ��� ��ü �����ϴ� ��Ŷ
// deviceId�� ������ ��
public class RequestBasketDeletePacket : IRequestPacket
{
    public RequestBasketDeletePacket() : base("/DeleteBasket")
    {
    }
}

// ��ٱ��� ������ ���� ��Ŷ
public class ResponseBasketDeletePacket : ResponsePacket
{
}
