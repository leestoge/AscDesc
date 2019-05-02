using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePrefab;
    public GameObject spikePrefab;
    private GameObject myPlatform;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(1, 6) > 1)
        {
            myPlatform = Instantiate(platformPrefab,
                new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (5 + Random.Range(0.5f, 1f))),
                Quaternion.identity);
        }
        else if(Random.Range(1, 6) == 2)
        {
            myPlatform = Instantiate(spikePrefab,
                new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (5 + Random.Range(0.5f, 1f))),
                Quaternion.identity);
        }
        else if (Random.Range(1, 6) == 4)
        {
            myPlatform = Instantiate(bigBouncePrefab,
                new Vector2(Random.Range(-2.2f, 2.2f), player.transform.position.y + (5 + Random.Range(0.5f, 1f))),
                Quaternion.identity);
        }

        Destroy(collision.gameObject);
    }
}
