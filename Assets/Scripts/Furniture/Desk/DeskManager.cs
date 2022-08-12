using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    public static DeskManager Instance;

    public List<Desk> List = new List<Desk>();

    private void Awake()
    {
        Instance = this;

        TBL_DESK.ForEachEntity(data =>
        {
            Desk desk= new Desk(data);

            List.Add(desk);
        });
    }
}
