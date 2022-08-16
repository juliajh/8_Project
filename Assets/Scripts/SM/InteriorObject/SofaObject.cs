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


    public override void RotationObject()
    {
        switch (direction)
        {
            case Direction.Front:
                {
                    //transform.Rotate(0, 0, 90);
                    direction = Direction.Right;
                    m_SpriteRenderer.sprite = m_Sofa.Data.RightImage;
                    //StartCoroutine(Spin());
                    //Rortate();
                }
                break;
            case Direction.Right:
                {
                    //transform.Rotate(0, 0, 90);
                    direction = Direction.Left;
                    m_SpriteRenderer.sprite = m_Sofa.Data.LeftImage;
                }
                break;
            case Direction.Left:
                {
                    //transform.Rotate(0, 0, 90);
                    direction = Direction.Front;
                    m_SpriteRenderer.sprite = m_Sofa.Data.FrontImage;
                    //Rortate();
                }
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
