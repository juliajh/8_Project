using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDeleteBtn : MonoBehaviour
{
    [SerializeField]
    GameObject[] allFurniture;
    public void AllDeleteButton()
    {
        FurnitureManager.Instance.ClearMap();
            
    }
}
