using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    Transform pivotPoint;
    [SerializeField]
    float spinSpeed = 5f;
    int direction;
    Vector3 movement;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        direction = 0;
        direction -= Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        direction += Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;
        print(direction);
    }

    void FixedUpdate() 
    {
        transform.RotateAround(pivotPoint.position, Vector3.forward, spinSpeed * Time.fixedDeltaTime * direction);
        transform.position += (movement * movementSpeed * Time.fixedDeltaTime);
    }
}
