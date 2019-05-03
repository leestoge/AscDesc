using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePrefab;
    public GameObject plankPrefab;
    public GameObject movingPrefab;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Platform"))
        {
            if (Random.Range(1, 7) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(bigBouncePrefab, new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
            else if (Random.Range(1, 7) == 2)
            {
                Destroy(collision.gameObject);
                Instantiate(plankPrefab, new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
            else if (Random.Range(1, 7) == 3)
            {
                Destroy(collision.gameObject);
                Instantiate(movingPrefab, new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f)));
            }
        }
        else if (collision.gameObject.name.StartsWith("Big"))
        {
            if (Random.Range(1, 7) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f)));              
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
        }
        else if (collision.gameObject.name.StartsWith("Plank"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name.StartsWith("Moving"))
        {
            if (Random.Range(1, 7) == 3)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f)));
            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (4 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
            }
        }
    }
}
