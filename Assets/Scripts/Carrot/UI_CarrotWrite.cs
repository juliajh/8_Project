using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CarrotWrite : MonoBehaviour
{

    public TextMeshProUGUI m_CategoryText;
    public TextMeshProUGUI m_FurnitureNameText;
    public TextMeshProUGUI m_PriceText;
    public TextMeshProUGUI m_TitleText;
    public TextMeshProUGUI m_ContextText;

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
            category = m_CategoryText.text,
            furnitureName = m_FurnitureNameText.text,
            price = m_PriceText.text,
            title = m_TitleText.text,
            context = m_ContextText.text
        };

        CarrotManager.Instance.CarrotList.Add(data);
    }

}
