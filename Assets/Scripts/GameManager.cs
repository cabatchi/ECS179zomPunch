using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PauseMenuController pauseMenuController;
    public ScoreManager scoreManager;
    public UnityEngine.UI.Image fadeImage;
    public SoundManager soundManager;

    void Start()
    {
        pauseMenuController.ResumeGame();
        scoreManager.ResetScore();
        soundManager.PlayMusicTrack("Theme");
        ZombieSpawner.currentWave = 1;
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