using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
        if (PauseMenu.IsPaused)
        {
            Application.Quit();   
        }
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void ReturnToMainMenu()
    {
        if (PauseMenu.IsPaused)
        {
            SceneManager.LoadScene("Main_Menu");   
        }
    }
}
