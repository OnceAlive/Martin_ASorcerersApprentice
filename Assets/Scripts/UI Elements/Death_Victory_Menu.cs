using UnityEngine;
using UnityEngine.SceneManagement;

public class Death_Victory_Menu : MonoBehaviour
{   
    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickBackMenu()
    {
        GameObject.FindGameObjectWithTag(Tags.T_Player).GetComponent<PlayerHealth>().Uninitialize();
        SceneManager.LoadScene("Main_Menu");
    }
}
