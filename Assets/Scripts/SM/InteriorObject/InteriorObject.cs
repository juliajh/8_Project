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
    public BoxCollider2D furnitureCollider;
    public Rigidbody2D furnitureRigidBody;



    public Direction direction = Direction.Front;

    public abstract void SetIndex(int index);

    private void Awake()
    {
        furnitureRigidBody = GetComponent<Rigidbody2D>();
        furnitureCollider = GetComponent<BoxCollider2D>();
        m_Material = GetComponent<SpriteRenderer>().material;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnMouseDown()
    {
        Debug.Log("Down");      
        isSelected = true;
        m_Material.EnableKeyword("OUTBASE_ON");
        gameObject.tag = "Furniture";

        FurnitureManager.Instance.SetCurrentInterObject(this);
        //UI_RotateButton.Instance.Show();
    }

    private void OnMouseDrag()
    {
        if (!isSelected) return;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (FurnitureType==FurnitureType.PhotoFrame ) 
        {
            worldPosition.x = Mathf.Clamp(worldPosition.x, (float)-4.4, (float)4.4);
            worldPosition.y = Mathf.Clamp(worldPosition.y, (float)3.5, (float)3.85);
        }

        /*worldPosition.x = Mathf.Clamp(worldPosition.x, (float)-4.39, (float)4.61);
        worldPosition.y = Mathf.Clamp(worldPosition.y, (float)-1.3, (float)3);
*/      worldPosition.z = 0;


        transform.position = worldPosition;
    }

    private void OnMouseUp()
    {
        isSelected = false;

        m_Material.DisableKeyword("OUTBASE_ON");

        //FurnitureManager.Instance.SetCurrentInterObject(null);
    }


    public virtual void RotationObject()
    {
        print("Rotate");
        direction = (Direction)((int)direction + 1);
        transform.Rotate(0, 0,90);
       
    }

    public virtual void DeleteObject() 
    {
        Destroy(gameObject);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            NuckBack(Vector2.right*20f);   
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            NuckBack(Vector2.left*20f);
        }

        if (collision.gameObject.CompareTag("Furniture")&&isSelected == true) 
        {

            NuckBack(Vector2.left*15f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RightWall") || collision.gameObject.CompareTag("LeftWall"))
        {
            StartCoroutine(StopRigidBody());
        }
        if (collision.gameObject.CompareTag("Furniture")) 
        {
            print(gameObject.name);
            StartCoroutine(StopRigidBody());
        }
    }
    
    IEnumerator StopRigidBody()
    {
        yield return new WaitForSeconds(0.1f);
        print("Start");
        furnitureCollider.isTrigger = true;
        furnitureRigidBody.bodyType = RigidbodyType2D.Kinematic;
        furnitureRigidBody.velocity = new Vector2(0, 0);

    }


    void NuckBack(Vector2 dir) 
    {
        print("NuckBack");
        //print(col);
        /*furnitureCollider = gameObject.GetComponent<BoxCollider2D>();
        furnitureRigidBody = gameObject.GetComponent<Rigidbody2D>();*/
        //furnitureCollider.isTrigger = false;

        furnitureRigidBody.gravityScale = 0f;
        furnitureRigidBody.bodyType = RigidbodyType2D.Dynamic;
        furnitureRigidBody.AddForce(dir);
        //furnitureRigidBody.velocity = new Vector2(1.4f, 0);
    }


}
