using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketButton : MonoBehaviour
{
    public void OnClickOpenButton()
    {
        UI_Basket.Instance.Open();
    }
}
