using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var a = TBL_DESK.GetEntity(2);

        Debug.Log(a.ColorType);
        Debug.Log(a.FrontImage);
        Debug.Log(a.BackImage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Desk
{
    public readonly TBL_DESK MetaData;


    public Desk(TBL_DESK metaData)
    {
        MetaData = metaData;
    }
}

public class DesckManger : MonoBehaviour
{
    public List<Desk> List;

    private void Start()
    {
        // capcacity
        List = new List<Desk>(TBL_DESK.CountEntities);

        TBL_DESK.ForEachEntity(data =>
        {
            Desk desk = new Desk(data);

            List.Add(desk);
        });
    }
}
