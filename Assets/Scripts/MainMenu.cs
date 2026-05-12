using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private LevelManager _levelManager;

    void Awake()
    {
        Time.timeScale = 1;
        _levelManager = FindAnyObjectByType<LevelManager>();
    }
    public void StartGame()
    {
        if (_levelManager != null) _levelManager.LoadScene();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
