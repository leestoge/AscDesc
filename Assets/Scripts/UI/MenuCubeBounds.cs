using UnityEngine;

public class MenuCubeBounds : MonoBehaviour
{
    public GameObject player;
    private Vector3 startPos;

    void Awake()
    {
        startPos = player.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == player)
        {
            player.transform.position = startPos;
        }
    }
}
