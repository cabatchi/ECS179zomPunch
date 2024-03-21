using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public SoundManager soundManager;

    void Start()
    {
        soundManager.PlayMusicTrack("Theme");
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("ZomPunch");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        controlsMenu.SetActive(true);
    }

    public void CloseControls()
    {
        controlsMenu.SetActive(false);
    }
}
