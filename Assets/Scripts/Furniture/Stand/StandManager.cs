using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandManager : MonoBehaviour
{
    public static StandManager Instance;

    public List<Stand> List = new List<Stand>();

    private void Awake()
    {
        Instance = this;

        TBL_STAND.ForEachEntity(data =>
        {
            Stand stand = new Stand(data);

            List.Add(stand);
        });
    }
}
