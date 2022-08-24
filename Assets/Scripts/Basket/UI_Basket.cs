using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Basket : MonoBehaviour
{
    public static UI_Basket Instance;

    public Transform ParentTransform;

    public UI_BasketItem Prefab;
    public TextMeshProUGUI countText;
    public List<UI_BasketItem> Items;
    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    private void Start()
    {
        Refresh();
    }


    public void Refresh()
    {
        var dataList = BasketManager.Instance.BasketList;
        int dataCount = dataList.Count;

        int itemCount = Items.Count;

        if (dataCount == 0)
        {
            for (int i = 0; i < itemCount; ++i)
            {
                Items[i].gameObject.SetActive(false);
            }

            return;
        }

        if (itemCount < dataCount)
        {
            for (int i = 0; i < dataCount - itemCount; ++i)
            {
                var newItem = Instantiate<UI_BasketItem>(Prefab);
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

    public void Open()
    {
        gameObject.SetActive(true);
        Refresh();
        BasketManager.Instance.OnChangeCallback += Refresh;
    }
    public void Close()
    {
        gameObject.SetActive(false);
        BasketManager.Instance.OnChangeCallback -= Refresh;
    }
}
