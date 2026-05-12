using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{



    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
