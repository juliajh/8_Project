using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Recommend : MonoBehaviour
{
    public static UI_Recommend Instance;

    public Transform ParentTransform;
    
    public UI_RecommendItem Prefab;
    
    public List<UI_RecommendItem> Items;
    private void Awake()
    {
        Instance = this;
    }
    
    
    public void Refresh()
    {
        var dataList = RecommendManager.Instance.List;
        int dataCount = dataList.Count;

        int itemCount = Items.Count;

        if (itemCount < dataCount)
        {
            for (int i = 0; i < dataCount - itemCount; ++i)
            {
                var newItem = Instantiate<UI_RecommendItem>(Prefab);
                newItem.transform.SetParent(ParentTransform);
                newItem.GetComponent<RectTransform>().localScale = Vector3.one;

                Items.Add(newItem);
            }

            itemCount = Items.Count;
        }

        for (int i = 0; i < itemCount; ++i)
        {
            if (i >= dataCount)
            {
                Items[i].gameObject.SetActive(false);
                continue;
            }
            
            Items[i].gameObject.SetActive(true);
            Items[i].Init(dataList[i]);
        }
    }
    
    
}
