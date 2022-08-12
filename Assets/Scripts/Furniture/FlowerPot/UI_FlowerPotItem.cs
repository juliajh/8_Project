using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FlowerPotItem : MonoBehaviour
{
    private FlowerPot m_FlowerPot;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(FlowerPot data)
    {
        m_FlowerPot = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_FlowerPot.Data.Name;
        m_IconImage.sprite = m_FlowerPot.Data.FrontImage;
    }

    public void OnClickItem()
    {
        Debug.Log($"{m_FlowerPot.Data.Index}");
    }
}
