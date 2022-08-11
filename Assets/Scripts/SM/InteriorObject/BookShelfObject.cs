using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfObject : InteriorObject
{
    private BookShelf m_BookShelf;

    public void Make(BookShelf bookShelf)
    {
        FurnitureType = FurnitureType.BookShelf;

        m_BookShelf = bookShelf;

        Index = m_BookShelf.Data.Index;

        m_SpriteRenderer.sprite = m_BookShelf.Data.FrontImage;
    }
}