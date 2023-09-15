using System;
using UnityEngine;
using UnityEngine.EventSystems;
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
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        if (PauseMenu.IsPaused)
        {
            SceneManager.LoadScene("Main_Menu");   
        }
    }
}
