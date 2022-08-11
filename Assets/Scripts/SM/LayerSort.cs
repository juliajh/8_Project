using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSort : MonoBehaviour
{
    public GameObject parentObject;
    public InteriorObject parentScript;
    public SpriteRenderer spriteRendererOfcollisionObjectParent = null;
    public SpriteRenderer parentSpriteRenderer;

    private void Start()
    {
       // parentObject = GetComponentInParent<GameObject>();

        parentScript = GetComponentInParent<InteriorObject>();

        parentSpriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && parentScript.isSelected == true) 
        {
            spriteRendererOfcollisionObjectParent = collision.GetComponentInParent<SpriteRenderer>();
            if (parentSpriteRenderer.sortingOrder <=spriteRendererOfcollisionObjectParent.sortingOrder) 
            {
                parentSpriteRenderer.sortingOrder = (int)parentObject.transform.position.y + spriteRendererOfcollisionObjectParent.sortingOrder;
            }
        }

    }
}
