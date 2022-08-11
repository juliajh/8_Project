using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{
    public static FurnitureManager Instance;

    public List<InteriorObject> Prefabs;

    public List<InteriorObject> InteriorObjects = new List<InteriorObject>(64);

    private void Awake()
    {
        Instance = this;
    }


    public void Make(FurnitureType furnitureType, int index)
    {
        InteriorObject obj = Instantiate<InteriorObject>(Prefabs[(int)furnitureType]);

        obj.transform.position = new Vector3(0, 0, 0);

        InteriorObjects.Add(obj);
    }
}
