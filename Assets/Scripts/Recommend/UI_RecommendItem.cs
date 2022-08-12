using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_RecommendItem : MonoBehaviour
{
    private RecommendResponseData m_Data;

    public Image m_IconImage;
    public TextMeshProUGUI m_NameText;
    public TextMeshProUGUI m_PriceText;
    public TextMeshProUGUI m_DescriptionText;

    public void Init(RecommendResponseData data)
    {
        m_Data = data;
        
        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Data.Title;
        m_PriceText.text = $"{Int32.Parse(m_Data.Price):N0}₩";
        m_DescriptionText.text = $"{m_Data.Category} / {m_Data.Color} / {m_Data.Brand}";
    }
}
