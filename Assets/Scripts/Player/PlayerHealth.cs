using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 15;
    [SerializeField] private float knockbackThrustAmount = .1f;
    [SerializeField] private float damageRecoveryTime = 1f;
    [SerializeField] private GameObject deathMenu;
    [SerializeField] private AudioClip deathSound;

    private static float currentHealth;
    private bool canTakeDamage = true;

    private Knockback knockback;
    private Flash flash;
    private static bool initialized = false;
    
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
    
    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        flash = GetComponent<Flash>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemy) 
        {
            TakeDamage(1, collision.gameObject.transform);
        }
    }
    
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    
    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(float damageAmount, Transform hitTransform)
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
            AudioSource.PlayClipAtPoint(deathSound, this.transform.position);
            currentHealth = 0;
            Time.timeScale = 0f;
            deathMenu.SetActive(true);
            initialized = false;
            //TODO: Game Over
        }
        StartCoroutine(DamageRecoverRoutine());
    }
    
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private IEnumerator DamageRecoverRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    public void Uninitialize()
    {
        initialized = false;
    }
}