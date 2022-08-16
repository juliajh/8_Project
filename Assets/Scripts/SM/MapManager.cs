using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] floors;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            floors[0].SetActive(false);
            floors[1].SetActive(true);
        }
    }
}
