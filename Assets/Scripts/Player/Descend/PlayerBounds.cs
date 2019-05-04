using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_X = -2.6f, max_X = 2.6f, min_Y = -5.6f;
    private bool outOfBounds;

    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > max_X)
        {
            temp.x = max_X; // dont allow player to go outside x bounds, set them to the max.
        }

        if (temp.x < min_X)
        {
            temp.x = min_X; // dont allow player to go outside x bounds, set them to the max.
        }

        transform.position = temp;

        if (temp.y <= min_Y) // if player is outside of y bounds (has died)
        {
            if (!outOfBounds)
            {
                outOfBounds = true;
                // ui?
                FindObjectOfType<AudioManager>().RandomizePitch("Death");
                FindObjectOfType<AudioManager>().Play("Death");
                GameManager.instance.RestartGame();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("TopSpike"))
        {
            transform.position = new Vector2(1000f, 1000f);
            FindObjectOfType<AudioManager>().RandomizePitch("Death");
            FindObjectOfType<AudioManager>().Play("Death");
            GameManager.instance.RestartGame();
        }
    }
}
