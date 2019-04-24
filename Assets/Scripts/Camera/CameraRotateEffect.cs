using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
    private PlayerMovement pmDesc;
    private PlayerMovementASC pmAsc;
    private float mod = 0.02f;
    private float zVal;

    void Awake()
    {
        pmDesc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        pmAsc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementASC>();
    }

    void Update()
    {
        if (pmAsc != null)
        {
            if (pmAsc.playerMoving)
            {
                RotateCam();
            }
        }
        else if (pmDesc != null)
        {
            if (pmDesc.playerMoving)
            {
                RotateCam();
            }
        }
        else
        {
            Debug.Log("Can't find one of the movement components.");
        }

    }

    void RotateCam()
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
