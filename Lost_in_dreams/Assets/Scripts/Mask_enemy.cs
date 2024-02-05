using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator animator;
    public float speed;
    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;
    private bool colliding;
    public LayerMask layer;
    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;
   
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent <Animator>();
    }

   
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding) 
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }

    }

    bool playerdestroy;
    void OnCollisionEnter2D(Collision2D collision)
        {
             if (collision.gameObject.tag == "Player") 
            {
                float height = collision.contacts[0].point.y - headPoint.position.y;

                if(height > 0 && !playerdestroy) 
                {
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                    speed = 0;
                    animator.SetTrigger("die");
                    boxCollider2D.enabled = false;
                    circleCollider2D.enabled = false;
                    rig.bodyType = RigidbodyType2D.Kinematic;
                    Destroy(gameObject, 0.33f);
                } else

                {
                    playerdestroy = true;
                    GameController.instance.ShowGameOver();
                    Destroy(collision.gameObject);
                }
            }    
        }
}
