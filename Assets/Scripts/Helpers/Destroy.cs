using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject player;
    public GameObject platformPrefab;
    public GameObject bigBouncePrefab;
    private GameObject myPlatform;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Random.Range(1, 6) > 1)
        {
            myPlatform = Instantiate(platformPrefab,
                new Vector2(Random.Range(-5.5f, 5 - 5f), player.transform.position.y + (5 + Random.Range(0.5f, 1f))),
                Quaternion.identity);
        }
        else
        {
            bigBouncePrefab = Instantiate(platformPrefab,
                new Vector2(Random.Range(-5.5f, 5 - 5f), player.transform.position.y + (5 + Random.Range(0.5f, 1f))),
                Quaternion.identity);
        }

        Destroy(collision.gameObject);
    }
}
