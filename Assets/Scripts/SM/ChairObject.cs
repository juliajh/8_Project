using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairObject : InteriorObject
{
    private BookShelf m_BookShelf;

    public override void SetIndex(int index)
    {
        Make(BookShelfManager.Instance.List[index]);
    }

    public void Make(BookShelf bookShelf)
    {
        FurnitureType = FurnitureType.BookShelf;

        m_BookShelf = bookShelf;

        Index = m_BookShelf.Data.Index;

        m_SpriteRenderer.sprite = m_BookShelf.Data.FrontImage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSelected == true)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
