using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bed : UI_Furniture
{
    [Header("�����۵�")]
    public List<UI_BedItem> Items;

    public void Start()
    {
        Refresh();
    }

    public override void Refresh()
    {
        var list = BedManager.Instance.List;
        int count = list.Count;

        for (int i = 0; i < count; ++i)
        {
            Items[i].Init(list[i]);
        }
    }
}
