using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PauseMenuController pauseMenuController;
    public ScoreManager scoreManager;
    public UnityEngine.UI.Image fadeImage;

    void Start()
    {
        pauseMenuController.ResumeGame();
        scoreManager.ResetScore();
    }

    public void TriggerGameOver()
    {
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