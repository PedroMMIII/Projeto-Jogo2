using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float FallingTime;
    private TargetJoint2D targetJoint2D;
    private BoxCollider2D boxCollider2D;
    void Start()
    {
        targetJoint2D = GetComponent<TargetJoint2D>();
        boxCollider2D = GetComponent <BoxCollider2D>();        
    }

    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag == "Player") 
        {
            Invoke("Falling", FallingTime);
        }       
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.layer == 8) 
        {
            Destroy(gameObject);
        } 
    }

    void Falling() 
    {
        targetJoint2D.enabled = false;
        boxCollider2D.isTrigger = true;
    }
   
}
