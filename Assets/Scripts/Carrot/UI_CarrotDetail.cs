using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CarrotDetail : MonoBehaviour
{
    private CarrotResponseData m_Data;

    public Image m_Image;
    public Dropdown m_CategoryText;
    public Text m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public Text m_TitleText;
    public Text m_ContextText;
    public Button DeleteBtn;
    public Button EditBtn;

    public static UI_CarrotDetail Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Init(CarrotResponseData data)
    {
        m_Data = data;
        DeleteBtn.gameObject.SetActive(false);
        EditBtn.gameObject.SetActive(false);
        Set();
    }

    private void Set()
    {
        if (m_Data == null)
        {
            return;
        }

        //m_Image.sprite = m_Data.imageSprite;
        m_CategoryText.value = int.Parse(m_Data.category);
        m_FurnitureNameText.text = m_Data.furnitureName;
        m_TitleText.text = m_Data.title;
        m_ContextText.text = m_Data.context;
        m_PriceText.text = m_Data.price;

        if(m_Data.uploaderId== UnityEngine.SystemInfo.deviceUniqueIdentifier)
        {
            DeleteBtn.gameObject.SetActive(true);
            EditBtn.gameObject.SetActive(true);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
       
    }

    public void Open()
    {
        m_Data = null;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);    
    }

    public void Delete()
    {
        CarrotManager.Instance.RemoveCarrot(m_Data);
        Close();
        UI_Carrot.Instance.Open();
    }

    public void Edit()
    {
        Close();
        Debug.Log("m_Data== "+m_Data);
        UI_CarrotWrite.Instance.Init(m_Data);
        UI_CarrotWrite.Instance.Open();
    }


}
