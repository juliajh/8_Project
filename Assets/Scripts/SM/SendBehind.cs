using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBehind : MonoBehaviour
{
    BoxCollider2D furnitureCollider;
    Rigidbody2D furnitureRigidBody;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Furniture")) 
        {
            furnitureCollider = collision.gameObject.GetComponent<BoxCollider2D>();
            furnitureRigidBody = collision.gameObject.GetComponent<Rigidbody2D>();
            furnitureCollider.isTrigger = false;

            furnitureRigidBody.gravityScale = 0f;
            furnitureRigidBody.bodyType = RigidbodyType2D.Dynamic;
            furnitureRigidBody.AddForce(new Vector2(0, 2));
            StartCoroutine(StopRigidBody());
        }
    }


    IEnumerator StopRigidBody() 
    {
        yield return new WaitForSeconds(1f);
        furnitureRigidBody.velocity = new Vector2(0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Furniture")) 
        {
            furnitureRigidBody.bodyType = RigidbodyType2D.Kinematic;
            furnitureCollider.isTrigger = true;
        }

    }
}
