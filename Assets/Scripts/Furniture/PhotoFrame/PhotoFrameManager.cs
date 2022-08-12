using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrameManager : MonoBehaviour
{
    public static PhotoFrameManager Instance;

    public List<PhotoFrame> List = new List<PhotoFrame>();

    private void Awake()
    {
        Instance = this;

        TBL_PHOTOFRAME.ForEachEntity(data =>
        {
            PhotoFrame pf= new PhotoFrame(data);

            List.Add(pf);
        });
    }
}
