using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileRange = 10f;
    [SerializeField] private bool isEnemyProjectile = false;
    
    private Vector2 startPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        this.startPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        DetectFireDistance();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
