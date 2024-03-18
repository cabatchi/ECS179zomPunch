using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static int score;

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