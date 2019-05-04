using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    public GameObject pauseMenu_UI;
    public GameObject gameplay_UI;
    private GameObject player;
    private SpriteRenderer playerSprite;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        GameIsPaused = false;
        gameplay_UI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        var tmp = playerSprite.color;
        tmp.a = 255f;
        playerSprite.color = tmp;
        pauseMenu_UI.SetActive(false);
        gameplay_UI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        var tmp = playerSprite.color;
        tmp.a = 0f;
        playerSprite.color = tmp;
        gameplay_UI.SetActive(false);
        pauseMenu_UI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        if (SceneManager.GetActiveScene().name == "Ascend")
        {
            Resume();
            GameManager.instance.RestartAscend();
        }
        else if (SceneManager.GetActiveScene().name == "Descend")
        {
            Resume();
            GameManager.instance.RestartDescend();
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
