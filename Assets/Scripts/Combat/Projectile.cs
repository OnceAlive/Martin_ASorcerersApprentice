using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] private bool isEnemyProjectile = false;
    
    private Vector2 startPosition;
    
    void Start()
    {
        this.startPosition = this.transform.position;
    }
    
    void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.T_Blocker))
        {
            Destroy(gameObject);
        }
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if(!collision.isTrigger && (enemyHealth || player))
        {
            if((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile))
            {
                enemyHealth?.TakeDamage(1);
                player?.TakeDamage(1, transform);
                Destroy(gameObject);
            }

        }
    }

    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    public void UpdateProjectileSpeed(float projectileSpeed)
    {
        this.projectileSpeed = projectileSpeed;
    }

    private void DetectFireDistance()
    {
        if(Vector3.Distance(transform.position, this.startPosition) > this.projectileRange)
        {
            Destroy(gameObject);
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * Time.deltaTime * projectileSpeed);
    }
}
