using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfManager : MonoBehaviour
{
    public static BookShelfManager Instance;

    public List<BookShelf> List = new List<BookShelf>();

    private void Awake()
    {
        Instance = this;

        TBL_BOOKSHELF.ForEachEntity(data =>
        {
            BookShelf bookshelf = new BookShelf(data);

            List.Add(bookshelf);
        });
    }
}
