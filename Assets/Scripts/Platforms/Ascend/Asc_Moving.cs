using UnityEngine;

public class Asc_Moving : MonoBehaviour
{
    private int leftRight;
    private bool switchUp;
    private float speed;
    private float max_X = 2.3f;
    public float speedMin;
    public float speedMax;

    void Awake()
    {
        leftRight = Random.Range(0, 2);

        if (leftRight == 1)
        {
            switchUp = true;
        }
        else
        {
            switchUp = false;
        }

        speed = Random.Range(speedMin, speedMax);
    }

    void Update()
    {
        if (gameObject.transform.position.x >= max_X && switchUp)
        {
            switchUp = false;
            leftRight = 0;
        }
        else if (gameObject.transform.position.x <= -max_X && switchUp == false)
        {
            switchUp = true;
            leftRight = 1;
        }
        else
        {
            if (leftRight == 0)
            {
                gameObject.transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
            }
            else if (leftRight == 1)
            {
                gameObject.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
            }
        }
    }
}
