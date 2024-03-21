using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score = 0;
    public GameObject scoreText;

    public void Update()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString("D4");
    }

    public static int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void SubtractScore(int value)
    {
        score -= value;
    }

    public void ResetScore()
    {
        score = 0;
    }
}