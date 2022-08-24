using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using check;

public class UI_CarrotWrite : MonoBehaviour
{
    public Image m_image;
    public InputField m_FurnitureNameText;
    public InputField m_PriceText;
    public InputField m_TitleText;
    public InputField m_ContextText;
    public Dropdown m_CategoryText;
    public static UI_CarrotWrite Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Clear();
    }

    public void AddCarrot()
    {
        Packet_Carrot data = new Packet_Carrot()
        {
            category = m_CategoryText.options[m_CategoryText.value].text,
            furnitureName = m_FurnitureNameText.text.ToString(),
            price = m_PriceText.text.ToString(),
            title = m_TitleText.text.ToString(),
            context = m_ContextText.text.ToString(),
            imageSprite = m_image.sprite
        };
        ImageUploader
                .Initialize()
                .SetTexture(m_image.sprite.texture)
                .SetFieldName("file")
                .SetFileName("file")
                .SetType(ImageType.JPG)
                .SetCategory(data.category) // ī�װ�
                .SetFurnitureName(data.furnitureName) // ������ (��ǰ���̹Ƿ� �ƹ��ų�)
                .SetPrice(data.price) // ����
                .SetTitle(data.title) // �Խñ� ����
                .SetContext(data.context) // �Խñ� ����
                .SetUploaderId() // DeviceId (�ڵ����� �ҷ���)
                .OnError(error => Debug.Log(error))
                .OnComplete(text => Debug.Log(text))
                .Upload();

        CarrotManager.Instance.CarrotList.Add(data);
        this.gameObject.SetActive(false);

        UI_Carrot.Instance.Open();
    }

    private void Clear()
    {
        m_FurnitureNameText.text = "";
        m_PriceText.text = "";
        m_TitleText.text = "";
        m_ContextText.text = "";
        m_CategoryText.value = 0;
    }
}
