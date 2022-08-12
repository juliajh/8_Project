using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StandItem : MonoBehaviour
{
    private Stand m_Stand;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(Stand data)
    {
        m_Stand = data;
        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Stand.Data.Name;
        m_IconImage.sprite = m_Stand.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        Debug.Log($"{m_Stand.Data.Index}");
    }
}
