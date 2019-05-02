using UnityEngine;
using UnityEngine.UI;

public class ASC_PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;
    [HideInInspector]
    public bool playerMoving;

    //ui
    public Text scoreText;
    private float topScore;

    void Awake()
    {
        topScore = 0.0f;
        rb2d = GetComponent<Rigidbody2D>();
        playerMoving = false;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        {
            playerMoving = true;
        }

        if (rb2d.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }

        scoreText.text = "Score: " + Mathf.Round(topScore);
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;
        velocity.x = moveInput * speed;
        rb2d.velocity = velocity;
    }
}
