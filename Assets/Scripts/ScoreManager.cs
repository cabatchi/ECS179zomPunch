using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;
    public GameObject scoreText;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(10);
        }

        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore(int value)
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }
}