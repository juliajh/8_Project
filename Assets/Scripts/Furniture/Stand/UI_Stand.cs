using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stand : UI_Furniture
{
    [Header("�����۵�")]
    public List<UI_StandItem> Items;

    public override void Refresh()
    {
        var list = StandManager.Instance.List;
        int count = list.Count;

        for (int i = 0; i < count; ++i)
        {
            Items[i].Init(list[i]);
        }
    }
}
