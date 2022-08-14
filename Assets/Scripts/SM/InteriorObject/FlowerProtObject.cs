using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerProtObject : InteriorObject
{
    //private Bed m_Chair;
    private FlowerPot m_FlowerPot;

    public override void SetIndex(int index)
    {
        Make(FlowerPotManager.Instance.List[index]);
    }

    public void Make(FlowerPot flowerPot)
    {
        FurnitureType = FurnitureType.FlowerPot;

        m_FlowerPot = flowerPot;

        Index = m_FlowerPot.Data.Index;

        m_SpriteRenderer.sprite = m_FlowerPot.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
