using UnityEngine;

public class ASC_PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;
    [HideInInspector]
    public bool playerMoving;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerMoving = false;
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            playerMoving = true;
        }
    }
}
