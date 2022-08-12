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

    public override void SetIndex(int index)
    {
        Make(BedManager.Instance.List[index]);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            switch (direction) 
            {
                case Direction.Front:
                    {
                        //transform.Rotate(0, 0, 90);
                        direction = Direction.Right;
                        m_SpriteRenderer.sprite = m_Bed.Data.RightImage;
                        //StartCoroutine(Spin());
                        //Rortate();
                    }
                    break;
                case Direction.Right:
                    {
                        direction = Direction.Left;
                        m_SpriteRenderer.sprite = m_Bed.Data.LeftImage;
                    }
                    break;
                case Direction.Left:
                    {
                        direction = Direction.Front;
                        m_SpriteRenderer.sprite = m_Bed.Data.FrontImage;
                        //Rortate();
                    }
                    break;
            }

            /*//m_SpriteRenderer.sprite = m_Bed.Data.RightImage;
            if (direction == Direction.Front)
            {
                print(direction);
                direction = Direction.Right;
                m_SpriteRenderer.sprite = m_Bed.Data.RightImage;
                Rortate();
                print(direction);
            }
            if (direction == Direction.Right) 
            {
                direction = Direction.Left;
                m_SpriteRenderer.sprite = m_Bed.Data.LeftImage;
                Rortate();
            }
            if (direction == Direction.Left)
            {
                direction = Direction.Front;
                m_SpriteRenderer.sprite = m_Bed.Data.FrontImage;
                Rortate();
            }*/


        }
    }


    IEnumerator Spin() 
    {
        yield return new WaitForSeconds(0.5f);
        

    }
}
