using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorObject : MonoBehaviour
{
    public SpriteRenderer triggerRenderer;

    public bool isSelected = false;
    public bool canArrangeMent = true;

    public Material m_Material;
    public SpriteRenderer m_SpriteRenderer;

    private void Awake()
    {
        m_Material = GetComponent<SpriteRenderer>().material;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       /* if (collision.gameObject.tag == "Interior" && isSelected == true)
        {
            Debug.Log("False");
            print(m_SpriteRenderer.sortingOrder);
            triggerRenderer = collision.GetComponent<SpriteRenderer>();
            if (m_SpriteRenderer.sortingOrder <= triggerRenderer.sortingOrder)
            {
                print(1);
                m_SpriteRenderer.sortingOrder = (int)transform.position.y + triggerRenderer.sortingOrder;
            }
        }*/
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");      

        isSelected = true;

        m_Material.EnableKeyword("OUTBASE_ON");

    }

    private void OnMouseDrag()
    {
        //Debug.Log("Down");

        if (!isSelected) return;


        // 게임 좌표료 변환
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        worldPosition.z = 0;



        worldPosition.x = Mathf.Clamp(worldPosition.x, (float)-4.1, (float)4.1);
        worldPosition.y = Mathf.Clamp(worldPosition.y, (float)-1.3, (float)3);
        transform.position = worldPosition;
        
    }

    private void OnMouseUp()
    {
        //Debug.Log("Up");

        isSelected = false;

        m_Material.DisableKeyword("OUTBASE_ON");

    }
}
