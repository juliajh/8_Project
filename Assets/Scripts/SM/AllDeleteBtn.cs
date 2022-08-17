using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDeleteBtn : MonoBehaviour
{
    [SerializeField]
    GameObject[] allFurniture;
    public void AllDeleteButton()
    {
        FurnitureManager.Instance.CurrentInterObject?.DeleteObject();
        allFurniture = GameObject.FindGameObjectsWithTag("Furniture");

        for (int i = 0; i < allFurniture.Length; i++)
        {
            DestroyObject(allFurniture[i]);

        }
    }
}
