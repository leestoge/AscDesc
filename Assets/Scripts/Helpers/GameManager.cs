using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestartAfter", 2f);
    }

    void RestartAfter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Descend");
    }
}
