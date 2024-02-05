using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float speed;
    public float movetime;
    public bool dirRight = true;
    private float time;
    void Update()
    {
        if(dirRight) 
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else 
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        time += Time.deltaTime;
        if (time >= movetime) 
        {
            dirRight = !dirRight;
            time = 0f;
        }
    }
}
