using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    public static ChairManager Instance;

    public List<Chair> List = new List<Chair>();

    private void Awake()
    {
        Instance = this;

        TBL_CHAIR.ForEachEntity(data =>
        {
            Chair chair = new Chair(data);

            List.Add(chair);
        });
    }
}
