using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBehaviour : MonoBehaviour
{
    [SerializeField]
    [Range(0,1)]
    private float fallSpeed;
    [SerializeField]
    private float scale;

    [SerializeField]
    private Transform spawnPoint;

    private Rigidbody2D rb;
    private LaunchBehaviour lb;
    private bool falling;

    void Awake()
    {
        lb = GetComponent<LaunchBehaviour>();
        rb = GetComponent<Rigidbody2D>(); 
        Spawn();
    }

    void Update()
    {
        if(falling == true)
        {
            if(transform.localScale.x > 0.3)
            {
                FallAnimation();
            }
            else
            {
                Spawn();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Trap") && lb.flying == false)
        {
            falling = true;
        }
    }

    private void FallAnimation()
    {
        transform.localScale *= (1 - fallSpeed);
    }

    private void Spawn()
    {
        falling = false;
        lb.flying = false;
        rb.velocity = Vector2.zero;
        transform.localScale = new Vector3(scale, scale, scale);
        transform.position = spawnPoint.position;
    }
}
