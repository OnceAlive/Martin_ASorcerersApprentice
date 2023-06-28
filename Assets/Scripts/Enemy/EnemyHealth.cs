using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    //[SerializeField] private Transform damageSource;

    private int currentHealth;
    private Knockback knockback;
    private Flash flash;

    private void Awake()
    {
        knockback = gameObject.GetComponent<Knockback>();
        flash = gameObject.GetComponent<Flash>();
    }

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        knockback.GetKnockedBack(GameObject.FindGameObjectWithTag(Tags.T_Player).transform, 2f);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeath());
    }

    private IEnumerator CheckDetectDeath()
    {
        yield return new WaitForSeconds(flash.restoreDefaultMaterialTime);
        detectDeath();
    }

    private void detectDeath()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}