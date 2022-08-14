using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaObject : InteriorObject
{
    //private Bed m_Chair;
    private Sofa m_Sofa;

    public override void SetIndex(int index)
    {
        Make(SofaManager.Instance.List[index]);
    }

    public void Make(Sofa sofa)
    {
        FurnitureType = FurnitureType.Sofa;

        m_Sofa = sofa;

        Index = m_Sofa.Data.Index;

        m_SpriteRenderer.sprite = m_Sofa.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
