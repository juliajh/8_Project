using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SofaItem : MonoBehaviour
{
    private Sofa m_Sofa;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(Sofa data)
    {
        m_Sofa = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Sofa.Data.Name;
        m_IconImage.sprite = m_Sofa.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        FurnitureManager.Instance.Make(FurnitureType.Sofa, m_Sofa.Data.Index);
        RecommendManager.Instance.Recommend(FurnitureType.Sofa, m_Sofa.Data.ColorType);
    }
}
