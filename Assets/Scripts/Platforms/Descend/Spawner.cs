using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platform_SpawnTimer = 1.7f;
    private float currentPlatform_SpawnTimer;

    private int platform_SpawnCount;

    public float min_X = -2, max_X = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        currentPlatform_SpawnTimer = platform_SpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        currentPlatform_SpawnTimer += Time.deltaTime;

        if (currentPlatform_SpawnTimer >= platform_SpawnTimer)
        {
            // spawn platform

            platform_SpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if (platform_SpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platform_SpawnCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platform_SpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platform_SpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }

                platform_SpawnCount = 0;

            }

            if (newPlatform)
            {
                newPlatform.transform.parent = transform;
            }

            currentPlatform_SpawnTimer = 0f;
        }
    }
}
