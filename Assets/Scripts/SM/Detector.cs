using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public FurnitureArrangemnet furnitureArrangemnet;
    public Camera mainCamera;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            print("input");
            print(Input.mousePosition);
            if (Physics.Raycast(ray,out hit,Mathf.Infinity)) 
            {
                if (hit.transform.CompareTag("Tile")) 
                {
                    furnitureArrangemnet.SpawnFurniture(hit.transform);
                }
            }
        }    
    }
}
