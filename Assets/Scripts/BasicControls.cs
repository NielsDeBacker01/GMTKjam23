using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicControls: MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    [SerializeField]
    float movementSpeed = 5f;
    Vector2 movement;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }
}