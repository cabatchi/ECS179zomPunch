using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PauseMenuController pauseMenuController;
    public ScoreManager scoreManager;
    public UnityEngine.UI.Image fadeImage;
    public SoundManager soundManager;

    public void Start()
    {
        pauseMenuController.ResumeGame();
        scoreManager.ResetScore();
        soundManager.PlayMusicTrack("Theme");
        ZombieSpawner.currentWave = 1; // Static variable to track the current wave
        ZombieSpawner.waveIsDone = false; // Static variable to track if the wave is done
    }

    public void TriggerGameOver()
    {
        soundManager.FadeMusicTrack("Theme", 0.5f);
        soundManager.PlaySoundEffect("Game Over");
        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack()
    {
        Color color = fadeImage.color;
        float fadeSpeed = 0.01f;

        while (color.a < 1)
        {
            color.a += fadeSpeed;
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene("Game Over");
    }
}