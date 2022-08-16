using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FloorItem : MonoBehaviour
{
    private Floor m_Floor;

    public Image m_IconImage;
    public int m_NumInt;

    

    public void Init(Floor data)
    {
        m_Floor = data;
        Set();
    }

    private void Set()
    {
        m_IconImage.sprite = m_Floor.Data.FrontImage;
        m_NumInt= m_Floor.Data.FloorNum;
    }    

    public void OnClickItem()
    {
        FloorManager.Instance.OnClickItem(m_NumInt);   
    }
}
