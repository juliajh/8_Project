using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorObject : MonoBehaviour
{
    private bool isSelected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if(collision.CompareTag("Interior"))
        {
            Debug.Log("False");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("Down");

        isSelected = true;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Down");

        if (!isSelected) return;


        // ���� ��ǥ�� ��ȯ
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        worldPosition.z = 0;

        transform.position = worldPosition; ;
    }

    private void OnMouseUp()
    {
        Debug.Log("Up");

        isSelected = false;
    }
}
