using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
    private PlayerMovement pm;
    private float mod = 0.02f;
    private float zVal;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.playerMoving)
        {
            Vector3 rot = new Vector3(0, 0, zVal);
            transform.eulerAngles = rot;

            zVal += mod;

            if (transform.eulerAngles.z >= 5.0f && transform.eulerAngles.z < 10.0f)
            {
                mod = -0.02f;
            }
            else if (transform.eulerAngles.z < 355.0f && transform.eulerAngles.z > 350.0f)
            {
                mod = 0.02f;
            }
        }
    }
}
