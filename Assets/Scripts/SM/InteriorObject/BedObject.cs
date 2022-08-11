using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedObject :InteriorObject
{
    private Bed m_Bed;
 
    public void Make(Bed bed)
    {
        FurnitureType = FurnitureType.Bed;

        m_Bed = bed;

        Index = m_Bed.Data.Index;

        m_SpriteRenderer.sprite = m_Bed.Data.FrontImage;
    }


}
