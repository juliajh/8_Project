using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BookShelfItem : MonoBehaviour
{
    private BookShelf m_BookShelf;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(BookShelf data)
    {
        m_BookShelf = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_BookShelf.Data.Name;
        m_IconImage.sprite = m_BookShelf.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        Debug.Log($"{m_BookShelf.Data.Index}");
    }
}
