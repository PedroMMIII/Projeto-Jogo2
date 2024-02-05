using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator animator;
    public float JumpTrampoline;

    void Start() 
    {
        animator = GetComponent<Animator>();    
    }
    void OnCollisionEnter2D(Collision2D collision2D) 
    {
        if (collision2D.gameObject.tag == "Player") 
        {
            animator.SetTrigger("Jump");
            collision2D.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, JumpTrampoline), ForceMode2D.Impulse);  
        }    
    }
}
