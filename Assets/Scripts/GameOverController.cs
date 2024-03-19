using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject scoreText;

    public void Start()
    {
        int score = ScoreManager.GetScore();
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString("D4");
    }

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("ZomPunch");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}