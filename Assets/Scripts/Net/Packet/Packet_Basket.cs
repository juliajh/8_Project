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


// 장바구니 불러오는 요청 패킷
public class RequestBasketLoadPacket : IRequestPacket
{
    public RequestBasketLoadPacket() : base("/LoadBasket")
    {
    }
}

// 장바구니 불러오는 수신 패킷
public class ResponseBasketLoadPacket : ResponsePacket
{
    public BasketResponseData[] Data { get; private set; }
}



// 장바구니 저장하는 요청 패킷
public class RequestBasketSavePacket : IRequestPacket
{
    public string Product { get; private set; }

    public RequestBasketSavePacket(string product) : base("/UpdateBasket")
    {
        this.Product = product;
    }
}

// 장바구니 저장하는 수신 패킷
public class ResponseBasketSavePacket : ResponsePacket
{
}
