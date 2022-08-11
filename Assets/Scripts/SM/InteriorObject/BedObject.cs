using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedObject :InteriorObject
{
    private Bed m_Bed;
 
    public void Make(Bed bed)
    {
        m_Bed = bed;

        m_SpriteRenderer.sprite = m_Bed.Data.FrontImage;
    }


}
