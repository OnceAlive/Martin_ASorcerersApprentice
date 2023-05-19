using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private CircleCollider2D range;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 1f;

    private bool isShooting = false;

    public void Shoot()
    {
        if(!isShooting)
        {
            StartCoroutine(shootRoutine());
        }
    }

    private IEnumerator shootRoutine()
    {
        isShooting=true;

        for(int i = 0; i < burstCount; i++)
        {
            Vector2 targetDirection = GetComponent<Player>().transform.position - this.transform.position;

            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.right = targetDirection;

            if(newBullet.TryGetComponent(out Projectile projectile))
            {
                projectile.UpdateProjectileSpeed(bulletMoveSpeed);
            }

            yield return new WaitForSeconds(timeBetweenBursts);
        }
        

        yield return new WaitForSeconds(restTime);
        isShooting = false;
    }
}
