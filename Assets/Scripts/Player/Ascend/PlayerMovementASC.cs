using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovementASC : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movement;

    public bool playerMoving;
    public float movementSpeed = 10f;

    void Awake()
    {
        playerMoving = false;
        rb = GetComponent<Rigidbody2D>();
        movement = 0f;
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * movementSpeed;
    }

    void FixedUpdate()
    {
        if (movement < 0f || movement > 0f)
        {
            playerMoving = true;
            Vector2 velocity = rb.velocity;
            velocity.x = movement;
            rb.velocity = velocity;
        }
        else
        {
            playerMoving = false;
        }
    }
}
