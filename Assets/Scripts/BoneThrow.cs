using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneThrow : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void Update()
    {
        transform.eulerAngles += Vector3.forward * 10;
        Destroy(this.gameObject, 5);
    }
}
