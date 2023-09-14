using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 15;
    [SerializeField] private float knockbackThrustAmount = .1f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private GameObject deathMenu;

    private static int currentHealth;
    private bool canTakeDamage = true;

    private Knockback knockback;
    private Flash flash;
    
    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag(Tags.T_Player);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag(Tags.T_MonsterBlocker).GetComponent<Collider2D>());
        if (!initialized)
        {
            currentHealth = maxHealth;
            initialized = true;
        }
    }
    private static bool initialized = false;
    
    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        flash = GetComponent<Flash>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        Debug.Log(enemy);
        if (enemy) 
        {
            TakeDamage(1, collision.gameObject.transform);
        }
    }
    
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    
    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if(!canTakeDamage)
        {
            return;
        }

        knockback.GetKnockedBack(hitTransform, knockbackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
            //TODO: Game Over
        }
        StartCoroutine(DamageRecoverRoutine());
    }

    private IEnumerator DamageRecoverRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}