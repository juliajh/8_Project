using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskObject : InteriorObject
{
    //private Bed m_Chair;
    private Desk m_Desk;

    public override void SetIndex(int index)
    {
        Make(DeskManager.Instance.List[index]);
    }

    public void Make(Desk desk)
    {
        FurnitureType = FurnitureType.Desk;

        m_Desk = desk;

        Index = m_Desk.Data.Index;

        m_SpriteRenderer.sprite = m_Desk.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
