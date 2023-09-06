using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Slider healthbarSlider;
    private PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        healthbarSlider = GetComponent<Slider>();
        playerHealth = GameObject.FindGameObjectWithTag(Tags.T_Player).GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        healthbarSlider.maxValue = playerHealth.GetMaxHealth();
        healthbarSlider.value = playerHealth.GetCurrentHealth();
    }
}
