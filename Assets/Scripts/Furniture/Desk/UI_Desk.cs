using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Desk : UI_Furniture
{
    [Header("아이템들")]
    public List<UI_DeskItem> Items;

    public override void Refresh()
    {
        var list = DeskManager.Instance.List;
        int count = list.Count;

        for (int i = 0; i < count; ++i)
        {
            Items[i].Init(list[i]);
        }
    }
}
