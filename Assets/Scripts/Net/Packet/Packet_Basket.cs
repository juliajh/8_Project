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
// deviceId만 보내면 됨
public class RequestBasketLoadPacket : IRequestPacket
{
    public RequestBasketLoadPacket() : base("/LoadBasket")
    {
    }
}

// 장바구니 불러오는 수신 패킷
// 상품 정보들을 받아온다
public class ResponseBasketLoadPacket : ResponsePacket
{
    public BasketResponseData[] Data { get; private set; }
}



// 장바구니 저장하는 요청 패킷
// 저장할 상품의 Link 문자열의 끝에 존재하는 id값 리스트를 string형태로 보내기
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



// 장바구니 전체 삭제하는 패킷
// deviceId만 보내면 됨
public class RequestBasketDeletePacket : IRequestPacket
{
    public RequestBasketDeletePacket() : base("/DeleteBasket")
    {
    }
}

// 장바구니 삭제한 수신 패킷
public class ResponseBasketDeletePacket : ResponsePacket
{
}
