using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PauseMenuController pauseMenuController;

    void Start()
    {
        pauseMenuController.ResumeGame();
    }
}