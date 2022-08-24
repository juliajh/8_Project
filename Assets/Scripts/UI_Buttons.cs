using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Buttons : MonoBehaviour
{
    public TextMeshProUGUI BasketCountText;

    private void Start()
    {
        CountBasket();
        BasketManager.Instance.OnChangeCallback += CountBasket;
    }

    public void AllDeleteButton()
    {
        FurnitureManager.Instance.ClearMap();
    }

    public void BasketOpenButton()
    {
        UI_Basket.Instance.Open();
    }

    public void CarrotOpenButton()
    {
        UI_Carrot.Instance.Open();
    }

    private void CountBasket()
    {
        int count= BasketManager.Instance.BasketList.Count;
        Debug.Log("COUNT=========="+count);
        BasketCountText.text = count.ToString();
    }

}
