using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CarrotWrite : MonoBehaviour
{
    public InputField m_FurnitureNameText;
    public InputField m_PriceText;
    public InputField m_TitleText;
    public InputField m_ContextText;
    public Dropdown m_CategoryText;

    private void Awake()
    {

        
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void AddCarrot()
    {
        Packet_Carrot data = new Packet_Carrot()
        {
            category = m_CategoryText.value.ToString(),
            furnitureName = m_FurnitureNameText.text.ToString(),
            price = m_PriceText.text.ToString(),
            title = m_TitleText.text.ToString(),
            context = m_ContextText.text.ToString()
        };

        CarrotManager.Instance.CarrotList.Add(data);
    }

}
