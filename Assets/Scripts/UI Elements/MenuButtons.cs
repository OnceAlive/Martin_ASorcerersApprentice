using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
