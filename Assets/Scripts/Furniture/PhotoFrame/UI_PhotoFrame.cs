using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PhotoFrame : UI_Furniture
{
    [Header("�����۵�")]
    public List<UI_PhotoFrameItem> Items;

    public override void Refresh()
    {
        var list = PhotoFrameManager.Instance.List;
        int count = list.Count;

        for (int i = 0; i < count; ++i)
        {
            Items[i].Init(list[i]);
        }
    }
}
