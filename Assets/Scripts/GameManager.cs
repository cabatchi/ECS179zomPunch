using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PauseMenuController pauseMenuController;
    public ScoreManager scoreManager;

    void Start()
    {
        pauseMenuController.ResumeGame();
        scoreManager.ResetScore();
    }
}