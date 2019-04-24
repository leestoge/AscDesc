using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip land, death, breakPlatform, GameOver;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LandSound()
    {
        soundFX.clip = land;
        soundFX.Play();
    }

    public void BreakSound()
    {
        soundFX.clip = breakPlatform;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = death;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = GameOver;
        soundFX.Play();
    }
}
