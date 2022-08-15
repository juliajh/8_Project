using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandObject : InteriorObject
{
    //private Bed m_Chair;
    private Stand m_Stand;

    public override void SetIndex(int index)
    {
        Make(StandManager.Instance.List[index]);
    }

    public void Make(Stand stand)
    {
        FurnitureType = FurnitureType.Stand;

        m_Stand = stand;

        Index = m_Stand.Data.Index;

        m_SpriteRenderer.sprite = m_Stand.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            RotationObject();
        }
    }


    public override void RotationObject() 
    {
        transform.Rotate(0, 0, 90);
    }
}
