using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bullet;

    private bool isShooting = false;

    public void Shoot()
    {
        Vector2 targetDirection = Player.INSTANCE.transform.position - transform.position;

        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.right = targetDirection;
    }
    /*
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
    }*/
}
