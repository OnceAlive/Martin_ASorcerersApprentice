using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject inGameUI;
    public static bool IsPaused = false;
    
    public void TogglePause()
    {
        if(gameObject.activeSelf)
        {
            inGameUI.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        else
        {
            inGameUI.SetActive(false);
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
    }
}
