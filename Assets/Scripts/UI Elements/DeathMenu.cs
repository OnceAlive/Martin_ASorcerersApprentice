using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{   
    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickBackMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
