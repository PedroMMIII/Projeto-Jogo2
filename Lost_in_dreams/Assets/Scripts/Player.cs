using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public int Speed;
   public float JumpForce;
   public bool IsJump;
   public bool doubleJump;
   private Rigidbody2D Rigidbody2D;
   private Animator Animator;
   bool isBlowing;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move() 
    {
        /* Move o personagem em uma posição
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;
        */

        float movement = Input.GetAxis("Horizontal");
        Rigidbody2D.velocity = new Vector2(movement * Speed, Rigidbody2D.velocity.y);

        if (movement > 0f) 
        {
            Animator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        
        if (movement < 0f) 
        {
            Animator.SetBool("Walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        
        if (movement == 0f) 
        {
            Animator.SetBool("Walk", false);
        }
        
    }

    void Jump() 
    {
        if (Input.GetButtonDown("Jump") && !isBlowing) 
        {
            if (IsJump == false) 
            {
                Rigidbody2D.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                Animator.SetBool("Jump", true);
            }
            else 
            {
                if (doubleJump) 
                {
                    Rigidbody2D.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.layer == 6) 
        {
            IsJump = false;
            Animator.SetBool("Jump", false);
        } 

        if (collision2D.gameObject.tag == "Spike") 
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }    

        if (collision2D.gameObject.tag == "Saw") 
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

    }

    void OnCollisionExit2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.layer == 6) 
        {
            IsJump = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.layer == 10) 
        {
            isBlowing = true;
        }    
    }

    void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.layer == 10) 
        {
            isBlowing = false;
        }
    }
}
