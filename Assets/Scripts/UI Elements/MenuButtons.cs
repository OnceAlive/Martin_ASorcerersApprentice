using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuButtons : MonoBehaviour
{
    [FormerlySerializedAs("storyText")] [SerializeField] private GameObject storyScreen;
    
    public void QuitGame()
    {
        if (PauseMenu.IsPaused)
        {
            Application.Quit();   
        }
    }

    public void OnClickPlay()
    {
        Time.timeScale = 1;
        storyScreen.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        if (PauseMenu.IsPaused)
        {
            GameObject.FindGameObjectWithTag(Tags.T_Player).GetComponent<PlayerHealth>().Uninitialize();
            SceneManager.LoadScene("Main_Menu");   
        }
    }
}
