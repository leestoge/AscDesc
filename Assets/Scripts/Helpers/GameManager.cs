using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void RestartAscend()
    {
        Invoke("RestartAscendAfter", 0.5f);
    }

    void RestartAscendAfter()
    {
        SceneManager.LoadScene("Ascend");
    }

    public void RestartDescend()
    {
        Invoke("RestartDescendAfter", 0.5f);
    }

    void RestartDescendAfter()
    {
        SceneManager.LoadScene("Descend");
    }
}
