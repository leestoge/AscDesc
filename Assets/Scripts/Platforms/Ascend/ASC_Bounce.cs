using UnityEngine;

public class ASC_Bounce : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 550f);
            }
        }
    }
}
