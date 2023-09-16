using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;
    [SerializeField] private GameObject heart;

    private float currentHealth;
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

    public void TakeDamage(float damage)
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
            if (Random.Range(0, 9) == 0)
            {
                Instantiate(heart, this.transform.position, Quaternion.identity);   
            }
            Destroy(gameObject);
        }
    }
}