using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaManager : MonoBehaviour
{
    public static SofaManager Instance;

    public List<Sofa> List = new List<Sofa>();

    private void Awake()
    {
        Instance = this;

        TBL_SOFA.ForEachEntity(data =>
        {
            Sofa sofa = new Sofa(data);

            List.Add(sofa);
        });
    }
}
