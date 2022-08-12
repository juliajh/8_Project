using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPotManager : MonoBehaviour
{
    public static FlowerPotManager Instance;

    public List<FlowerPot> List = new List<FlowerPot>();

    private void Awake()
    {
        Instance = this;

        TBL_FLOWERPOT.ForEachEntity(data =>
        {
            FlowerPot flowerPot = new FlowerPot(data);

            List.Add(flowerPot);
        });
    }
}
