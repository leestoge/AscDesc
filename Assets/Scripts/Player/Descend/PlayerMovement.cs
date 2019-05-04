using UnityEngine;
using UnityEngine.UI;

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

    //ui
    public Text scoreText;
    private int Score;

    void Awake()
    {
        playerMoving = false;
        allowJump = false;
        rb = GetComponent<Rigidbody2D>();
        Score = 0;

        if (scoreText == null)
        {
            Debug.Log("Menu Cube");
        }
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            playerMoving = true;
        }

        movement = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            allowJump = false;
        }

        if (allowJump && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            FindObjectOfType<AudioManager>().RandomizePitch("JumpDesc");
            FindObjectOfType<AudioManager>().Play("JumpDesc");
            allowJump = false;
        }

        //ui
        if (scoreText != null)
        {
            scoreText.text = "Score: " + Score;
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
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (movement < 0f) // press a/left arrow
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    public void PlatformMove(float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }

    public void IncreaseScore()
    {
        Score = Score + Random.Range(1, 6);
    }
}
