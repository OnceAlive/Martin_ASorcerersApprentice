using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TogglePause()
    {
        if(gameObject.activeSelf)
        {
            healthBar.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            healthBar.SetActive(false);
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
       
    }
}
