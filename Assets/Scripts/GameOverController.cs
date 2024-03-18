using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject scoreText;

    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync("ZomPunch");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}