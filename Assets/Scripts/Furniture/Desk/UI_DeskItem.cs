using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DeskItem : MonoBehaviour
{
    private Desk m_Desk;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(Desk data)
    {
        m_Desk = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Desk.Data.Name;
        m_IconImage.sprite = m_Desk.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        FurnitureManager.Instance.Make(FurnitureType.Desk, m_Desk.Data.Index);
        RecommendManager.Instance.Recommend(FurnitureType.Desk, m_Desk.Data.ColorType);
    }
}
