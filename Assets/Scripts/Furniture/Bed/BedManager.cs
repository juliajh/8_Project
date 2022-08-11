using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedManager : MonoBehaviour
{
    public static BedManager Instance;

    public List<Bed> List = new List<Bed>();

    private void Awake()
    {
        Instance = this;

        TBL_BED.ForEachEntity(data =>
        {
            Bed bed = new Bed(data);

            List.Add(bed);
        });
    }
}
