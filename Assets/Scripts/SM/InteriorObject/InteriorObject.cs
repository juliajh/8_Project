using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Front,
    Back,
    Left,
    Right,

    Count,
}

public abstract class InteriorObject : MonoBehaviour
{
    public FurnitureType FurnitureType;
    public int Index;

    public SpriteRenderer triggerRenderer;

    public bool isSelected = false;
    public bool canArrangeMent = true;

    public Material m_Material;
    public SpriteRenderer m_SpriteRenderer;

    public Direction Direction = Direction.Front;

    public abstract void SetIndex(int index);

    private void Awake()
    {
        m_Material = GetComponent<SpriteRenderer>().material;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        Debug.Log("Down");      

        isSelected = true;

        m_Material.EnableKeyword("OUTBASE_ON");

    }

    private void OnMouseDrag()
    {
        if (!isSelected) return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        worldPosition.x = Mathf.Clamp(worldPosition.x, (float)-4.1, (float)4.1);
        worldPosition.y = Mathf.Clamp(worldPosition.y, (float)-1.3, (float)3);
        worldPosition.z = 0;


        transform.position = worldPosition;
    }

    private void OnMouseUp()
    {
        isSelected = false;

        m_Material.DisableKeyword("OUTBASE_ON");
    }


    public void Rortate()
    {
        Direction = (Direction)((int)Direction + 1);

        if(Direction == Direction.Count)
        {
            Direction = Direction.Front;
        }
    }
  
}
