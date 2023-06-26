using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private int projectilesPerBurst;
    [SerializeField][Range(0, 359)] private float angleSpread;
    [SerializeField] private float startingDistance = .1f;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;
    [SerializeField] private bool stagger;
    [SerializeField] private bool oscillate;

    private bool isShooting = false;
    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag(Tags.T_Player);
    }

    public void Shoot()
    {
        if (!isShooting)
        {
            StartCoroutine(ShootRoutine());
        }
    }
    
    private IEnumerator ShootRoutine()
    {
        isShooting=true;
        float timeBetweenProjectiles = stagger ? timeBetweenBursts / projectilesPerBurst : 0f;
        
        TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle);

        for(int i = 0; i < burstCount; i++)
        {
            if (!oscillate)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);
            }

            if (oscillate && i % 2 != 1)
            {
                TargetConeOfInfluence(out startAngle, out currentAngle, out angleStep, out endAngle);
            }
            else
            {
                if (oscillate)
                {
                    currentAngle = endAngle;
                    endAngle = startAngle;
                    startAngle = currentAngle;
                    angleStep *= -1;
                }
            }
            
            for (int j = 0; j < projectilesPerBurst; j++)
            {
                Vector2 position = FindBulletSpawnPosition(currentAngle);

                GameObject newBullet = Instantiate(bullet, position, Quaternion.identity);
                newBullet.transform.right = newBullet.transform.position - transform.position;

                if(newBullet.TryGetComponent(out Projectile projectile))
                {
                    projectile.UpdateProjectileSpeed(bulletMoveSpeed);
                }

                currentAngle += angleStep;

                if (stagger)
                {
                    yield return new WaitForSeconds(timeBetweenProjectiles);
                }
            }

            currentAngle = startAngle;

            if (!stagger)
            {
                yield return new WaitForSeconds(timeBetweenBursts);   
            }
        }
        
        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }

    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
    {
        Vector2 targetDirection = target.transform.position
                                  - this.transform.position;

        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0f;

        if (angleSpread != 0)
        {
            angleStep = angleSpread / (projectilesPerBurst - 1);
            halfAngleSpread = angleSpread / 2;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngle = startAngle;
        }
    }

    private Vector2 FindBulletSpawnPosition(float currentAngle)
    {
        float x = transform.position.x + startingDistance * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = transform.position.y + startingDistance * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        return new Vector2(x, y);
    }
}
