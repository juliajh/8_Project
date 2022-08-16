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


    public override void RotationObject()
    {
        switch (direction)
        {
            case Direction.Front:
                {
                    //transform.Rotate(0, 0, 90);
                    direction = Direction.Right;
                    m_SpriteRenderer.sprite = m_Chair.Data.RightImage;
                    //StartCoroutine(Spin());
                    //Rortate();
                }
                break;
            case Direction.Right:
                {
                    //transform.Rotate(0, 0, 90);
                    direction = Direction.Left;
                    m_SpriteRenderer.sprite = m_Chair.Data.LeftImage;
                }
                break;
            case Direction.Left:
                {
                    //transform.Rotate(0, 0, 90);
                    direction = Direction.Front;
                    m_SpriteRenderer.sprite = m_Chair.Data.FrontImage;
                    //Rortate();
                }
                break;
        }
    }



}
