using UnityEngine;

public class ASC_Bounce : MonoBehaviour
{
    public float jumpForce;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                if (rb.velocity.y <= 0)
                {
                    Vector2 velocity = rb.velocity;
                    velocity.y = jumpForce;
                    rb.velocity = velocity;
                }
            }
        }
    }
}
