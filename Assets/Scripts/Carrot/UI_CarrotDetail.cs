using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CarrotDetail : MonoBehaviour
{
    private Packet_Carrot m_Data;

    public Image m_Image;
    public Text m_CategoryText;
    public Text m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public Text m_TitleText;
    public Text m_ContextText;

    public static UI_CarrotDetail Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(Packet_Carrot data)
    {
        m_Data = data;

        Set();
    }

    private void Set()
    {
        if (m_Data == null)
        {
            return;
        }

        m_Image.sprite = m_Data.imageSprite;
        m_CategoryText.text = m_Data.category;
        m_FurnitureNameText.text = m_Data.furnitureName;
        m_TitleText.text = m_Data.title;
        m_ContextText.text = m_Data.context;
        m_PriceText.text = m_Data.price;

    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
       
    }

    public void Close()
    {
        gameObject.SetActive(false);
        m_Data = null;
    }

    public void Delete()
    {
        CarrotManager.Instance.RemoveCarrot(m_Data);
    }


}
