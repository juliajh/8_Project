using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BedItem : MonoBehaviour
{
    private Bed m_Bed;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(Bed data)
    {
        m_Bed = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_Bed.Data.Name;
        m_IconImage.sprite = m_Bed.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        Debug.Log($"{m_Bed.Data.Index}");

        FurnitureManager.Instance.Make(FurnitureType.Bed, m_Bed.Data.Index);
    }
}
