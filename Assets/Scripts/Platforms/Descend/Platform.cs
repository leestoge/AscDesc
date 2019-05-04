using UnityEngine;

public class Platform : MonoBehaviour
{
    public float move_Speed = 2f;
    public float bound_Y = 6f;

    public bool movingPlatform_Left, movingPlatform_Right, isBreakable, isSpike, isPlatform;

    private Animator anim;

    public float movingPlatformLeft_Speed = -1f;
    public float movingPlatformRight_Speed = 1f;

    private PlayerMovement pm;

    void Awake()
    {
        pm = FindObjectOfType<PlayerMovement>();
        if (isBreakable)
        {
            anim = GetComponent<Animator>();
        }
    }

    void Update()
    {
        Move();      
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
        {
            Destroy(gameObject);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DestroyGameObject", 0.35f);
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
        FindObjectOfType<AudioManager>().RandomizePitch("Break");
        FindObjectOfType<AudioManager>().Play("Break");
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player"))
        {
            if (isSpike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                FindObjectOfType<AudioManager>().RandomizePitch("Death");
                FindObjectOfType<AudioManager>().Play("Death");
                GameManager.instance.RestartDescend();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (isBreakable)
            {
                pm.IncreaseScore();
                FindObjectOfType<AudioManager>().RandomizePitch("Land");
                FindObjectOfType<AudioManager>().Play("Land");
                anim.Play("Break");
            }

            if (isPlatform)
            {
                pm.IncreaseScore();
                FindObjectOfType<AudioManager>().RandomizePitch("Land");
                FindObjectOfType<AudioManager>().Play("Land");
            }

            if (movingPlatform_Left || movingPlatform_Right)
            {
                pm.IncreaseScore();
                FindObjectOfType<AudioManager>().Play("Moving");
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (movingPlatform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(movingPlatformLeft_Speed);
            }

            if (movingPlatform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(movingPlatformRight_Speed);
            }
        }
    }

    void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            if (movingPlatform_Right || movingPlatform_Left)
            {
                FindObjectOfType<AudioManager>().Stop("Moving");
            }

            pm.isGrounded = false;
            pm.allowJump = true;
        }
    }
}
