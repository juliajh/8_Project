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
    private Bed m_Bed;

    public FurnitureType FurnitureType;
    public int Index;

    public SpriteRenderer triggerRenderer;

    public bool isSelected = false;
    public bool canArrangeMent = true;

    public Material m_Material;
    public SpriteRenderer m_SpriteRenderer;

    public Direction direction = Direction.Front;

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
        gameObject.tag = "Furniture";

    }

    private void OnMouseDrag()
    {
        if (!isSelected) return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        worldPosition.x = Mathf.Clamp(worldPosition.x, (float)-4.39, (float)4.61);
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
        print("Rotate");
        direction = (Direction)((int)direction + 1);

       
    }
    BoxCollider2D furnitureCollider;
    Rigidbody2D furnitureRigidBody;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            NuckBack(new Vector2(10, 0));   
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            NuckBack(new Vector2(-10, 0));
        }

        if (collision.gameObject.CompareTag("Furniture")&&isSelected == true) 
        {
            NuckBack(new Vector3(-10, 0));
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall") || collision.gameObject.CompareTag("LeftWall") || collision.gameObject.CompareTag("Furniture"))
        {
            StartCoroutine(StopRigidBody());
        }
    }
    
    IEnumerator StopRigidBody()
    {
        yield return new WaitForSeconds(0.2f);
        furnitureRigidBody.velocity = new Vector2(0, 0);
        furnitureCollider.isTrigger = false;
        furnitureRigidBody.bodyType = RigidbodyType2D.Kinematic;

    }


    void NuckBack(Vector2 dir) 
    {
        print("NuckBack");
        //print(col);
        furnitureCollider = gameObject.GetComponent<BoxCollider2D>();
        furnitureRigidBody = gameObject.GetComponent<Rigidbody2D>();
        //furnitureCollider.isTrigger = false;

        furnitureRigidBody.gravityScale = 0f;
        furnitureRigidBody.bodyType = RigidbodyType2D.Dynamic;
        furnitureRigidBody.AddForce(dir);
        furnitureRigidBody.velocity = new Vector2(0.5f, 0);
    }


}
