using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_RotateButton : MonoBehaviour
{
    public static UI_RotateButton Instance;
    public List<GameObject> allFurnitureObject;
   
    public Vector3 offset;


    private void Awake()
    {
        Instance = this;

        Hide();
    }



    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    
    public void OnClickRotateButton()
    {
        FurnitureManager.Instance.CurrentInterObject?.RotationObject();
    }


    public void LateUpdate()
    {
        if(FurnitureManager.Instance.CurrentInterObject == null)
        {
            Hide();
            return;
        }

        Vector3 newPosition = FurnitureManager.Instance.CurrentInterObject.transform.position + offset;
        newPosition.z = 0;

        this.transform.position = newPosition;
    }
}
