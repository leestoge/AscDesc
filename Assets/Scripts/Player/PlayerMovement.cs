using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded;
    [HideInInspector]
    public bool playerMoving;

    public Transform feetPos;
    public float checkRadius;
    public float moveSpeed = 2f;
    public float jumpForce = 1f;   
    public LayerMask whatIsGround;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

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
