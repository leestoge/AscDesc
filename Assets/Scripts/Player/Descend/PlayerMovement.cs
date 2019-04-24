using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isGrounded;
    [HideInInspector]
    public bool playerMoving;

    public Transform feetPos;
    public float checkRadius;
    public float moveSpeed = 2f;
    public float jumpForce = 1f;   
    public LayerMask whatIsGround;

    public bool allowJump;

    private float movement;

    void Awake()
    {
        allowJump = false;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            allowJump = false;
        }

        if (allowJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            allowJump = false;
        }     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (movement > 0f) // press d/right arrow
        {
            playerMoving = true;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (movement < 0f) // press a/left arrow
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
