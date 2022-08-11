using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureArrangemnet : MonoBehaviour
{
    public GameObject furniture;


    public void SpawnFurniture(Transform tileTransform) 
    {
        Instantiate(furniture, tileTransform.position, Quaternion.identity);
    }
}
