using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoFrameObject : InteriorObject
{
    //private Bed m_Chair;
    private PhotoFrame m_PhotoFrame;

    public override void SetIndex(int index)
    {
        Make(PhotoFrameManager.Instance.List[index]);
    }

    public void Make(PhotoFrame photoFrame)
    {
        FurnitureType = FurnitureType.PhotoFrame;

        m_PhotoFrame = photoFrame;

        Index = m_PhotoFrame.Data.Index;

        m_SpriteRenderer.sprite = m_PhotoFrame.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
