using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool flying;
    private Rigidbody2D rb;

    void Awake()
    {
        flying = false;
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if(rb.velocity == Vector2.zero)
        {
            flying = false;
        }
    }

    public void Launch(Vector2 force)
    {
        if(flying == false) {
            flying = true;
            rb.AddForce(force);
        }
    }
}
