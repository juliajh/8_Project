using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public static FloorManager Instance;

    public List<Floor> List = new List<Floor>();

    public List<GameObject> floors;

    private void Awake()
    {
        Instance = this;

        TBL_FLOOR.ForEachEntity(data =>
        {
            Floor floor = new Floor(data);

            List.Add(floor);
        });
    }

    private void Start()
    {
        foreach (GameObject floor in floors)
        {
            floor.SetActive(false);
        }
    }

    public void OnClickItem(int m_NumInt)
    {
        foreach (GameObject floor in floors)
        {
            floor.SetActive(false);
        }
        floors[m_NumInt].SetActive(true);
    }
}
