using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 2f;

    public bool playerMoving;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f) // press d/right arrow
        {
            playerMoving = true;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f) // press a/left arrow
        {
            playerMoving = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        else
        {
            playerMoving = false;
        }
    }

    public void PlatformMove(float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }
}
