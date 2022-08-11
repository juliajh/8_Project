using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfObject : InteriorObject
{
    private BookShelf m_BookShelf;

    public void Make(BookShelf bookShelf)
    {
        m_BookShelf = bookShelf;

        m_SpriteRenderer.sprite = m_BookShelf.Data.FrontImage;
    }
}