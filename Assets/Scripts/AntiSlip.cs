using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiSlip : MonoBehaviour
{
    [SerializeField]
    new Rigidbody2D rigidbody;
    
    [SerializeField]
    private float weight;
    
    void Start() {
        rigidbody = this.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity.magnitude < .01 * weight) {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
