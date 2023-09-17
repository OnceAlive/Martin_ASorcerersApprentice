using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int healthAmount = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Tags.T_Player))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.Heal(healthAmount);
            Destroy(gameObject);
        }
    }
}
