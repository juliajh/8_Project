using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Basket : MonoBehaviour
{
    public static UI_Basket Instance;

    public Transform BasketParentTransform;
    public Transform RelativeParentTransform;
    
    public UI_BasketItem Prefab;
    public UI_BasketRelativeItem RelativePrefab;
    
    public TextMeshProUGUI countText;
    public List<UI_BasketItem> Items;
    public List<UI_BasketRelativeItem> RelativeItems;
    
    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    private void Start()
    {
        Refresh();
        RecommandRefresh();
    }

    
    public void RecommandRefresh()
    {
        var dataList = BasketManager.Instance.RelativeList;
        int dataCount = dataList.Count;

        int itemCount = RelativeItems.Count;

        if (dataCount == 0)
        {
            for (int i = 0; i < itemCount; ++i)
            {
                RelativeItems[i].gameObject.SetActive(false);
            }

            return;
        }

        if (itemCount < dataCount)
        {
            for (int i = 0; i < dataCount - itemCount; ++i)
            {
                var newItem = Instantiate<UI_BasketRelativeItem>(RelativePrefab);
                newItem.transform.SetParent(RelativeParentTransform);
                newItem.GetComponent<RectTransform>().localScale = Vector3.one;

                RelativeItems.Add(newItem);
            }

            itemCount = RelativeItems.Count;
        }

        for (int i = 0; i < itemCount; ++i)
        {
            if (i >= dataCount)
            {
                RelativeItems[i].gameObject.SetActive(false);
                continue;
            }

            RelativeItems[i].gameObject.SetActive(true);
            RelativeItems[i].Init(dataList[i]);
        }
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
                newItem.transform.SetParent(BasketParentTransform);
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
        RecommandRefresh();
        BasketManager.Instance.BasketChangeCallback += Refresh;
        BasketManager.Instance.RelativeChangeCallback += RecommandRefresh;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        BasketManager.Instance.BasketChangeCallback -= Refresh;
        BasketManager.Instance.RelativeChangeCallback -= RecommandRefresh;
    }
}
