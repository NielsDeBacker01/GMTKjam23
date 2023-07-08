using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBehaviour : MonoBehaviour
{
    [SerializeField]
    private float flyHeightScale;
    [HideInInspector]
    public bool flying;
    private Rigidbody2D rb;
    private Transform oldLocation;
    private float oldScale;

    void Awake()
    {
        flying = false;
        rb = GetComponent<Rigidbody2D>();
        oldScale = transform.localScale.x; 
    }

    void Update()
    {
        if(rb.velocity == Vector2.zero && flying == true)
        {
            flying = false;
            transform.localScale = new Vector3(oldScale, oldScale, oldScale);
        }
    }

    public void Launch(Vector2 force)
    {
        if(flying == false) {
            flying = true;
            rb.AddForce(force);
            transform.localScale = new Vector3(flyHeightScale, flyHeightScale, flyHeightScale);
        }
    }
}
