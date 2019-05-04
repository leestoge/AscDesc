using UnityEngine;

public class Asc_Plank : MonoBehaviour
{
    public float jumpForce;
    public GameObject regularPlatform;
    private EdgeCollider2D collider;
    private Rigidbody2D[] rb2ds;
    private Animator PlankBreak;

    void Awake()
    {
        regularPlatform.transform.parent = null;
        PlankBreak = GetComponent<Animator>();
        rb2ds = GetComponentsInChildren<Rigidbody2D>();
        collider = GetComponent<EdgeCollider2D>();
        collider.enabled = true;

        foreach (Rigidbody2D rb2d in rb2ds)
        {
            rb2d.isKinematic = true;
        }
    }

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
                    FindObjectOfType<AudioManager>().RandomizePitch("Break");
                    FindObjectOfType<AudioManager>().Play("Break");
                    collider.enabled = false;
                    PlankBreak.SetTrigger("Break");

                    foreach (Rigidbody2D rb2d in rb2ds)
                    {
                        rb2d.transform.parent = null;
                        rb2d.isKinematic = false;
                        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y , Random.Range(0, 360));
                        float speed = 600;
                        Vector3 force = Vector3.down;
                        force = new Vector3(force.x, -1, force.z);
                        rb2d.AddForce(force * speed);
                        Destroy(rb2d.gameObject, 1f);
                    }
                    Destroy(gameObject, 1f);
                }
            }
        }
    }
}
