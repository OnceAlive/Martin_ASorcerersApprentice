using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject player;
    public static bool IsPaused = false;
    
    public void TogglePause()
    {
        if(gameObject.activeSelf)
        {
            healthBar.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        else
        {
            healthBar.SetActive(false);
            gameObject.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
       
    }
}
