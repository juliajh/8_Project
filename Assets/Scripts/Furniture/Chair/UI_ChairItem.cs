using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ChairItem : MonoBehaviour
{
    private Chair m_Chair;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(Chair data)
    {
        m_Chair = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Chair.Data.Name;
        m_IconImage.sprite = m_Chair.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        Debug.Log($"{m_Chair.Data.Index}");
    }
}
