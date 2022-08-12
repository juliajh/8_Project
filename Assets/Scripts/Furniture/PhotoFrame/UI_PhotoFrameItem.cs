using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PhotoFrameItem : MonoBehaviour
{
    private PhotoFrame m_PhotoFrame;

    public Image m_IconImage;
    public Text m_NameText;

    public void Init(PhotoFrame data)
    {
        m_PhotoFrame = data;

        Set();
    }

    private void Set()
    {
        m_NameText.text = m_PhotoFrame.Data.Name;
        m_IconImage.sprite = m_PhotoFrame.Data.FrontImage;
    }    

    public void OnClickItem()
    {
        Debug.Log($"{m_PhotoFrame.Data.Index}");
    }
}
