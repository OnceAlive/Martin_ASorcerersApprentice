using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject storyText;
    
    public void QuitGame()
    {
        if (PauseMenu.IsPaused)
        {
            Application.Quit();   
        }
    }

    public void OnClickPlay()
    {
        
        storyText.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        if (PauseMenu.IsPaused)
        {
            SceneManager.LoadScene("Main_Menu");   
        }
    }
}
