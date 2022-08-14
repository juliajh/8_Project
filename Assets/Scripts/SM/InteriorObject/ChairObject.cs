using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairObject : InteriorObject
{
    //private Bed m_Chair;
    private Chair m_Chair;

    public override void SetIndex(int index)
    {
        Make(ChairManager.Instance.List[index]);
    }

    public void Make(Chair chair)
    {
        FurnitureType = FurnitureType.Chair;

        m_Chair = chair;

        Index = m_Chair.Data.Index;

        m_SpriteRenderer.sprite = m_Chair.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }



}
