using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Carrot : MonoBehaviour
{
    public static UI_Carrot Instance;

    public Transform ParentTransform;
    public UI_CarrotItem Prefab;
    public List<UI_CarrotItem> Items;

    private void Awake()
    {
        Instance = this;

        gameObject.SetActive(false);
    }

    
    public void Refresh()
    {
        var dataList = CarrotManager.Instance.CarrotList;
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
                var newItem = Instantiate<UI_CarrotItem>(Prefab);
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

        CarrotManager.Instance.OnChangeCallback += Refresh;

    }
    public void Close()
    {
        gameObject.SetActive(false);
        
        CarrotManager.Instance.OnChangeCallback -= Refresh;
    }

    public void Write()
    {
        Close();
        UI_CarrotWrite.Instance.Open();
    }


}
