using System.Collections;
using UnityEngine;

public class Fire : Spell
{
    [SerializeField] private GameObject fire;

    private const int numberOfBursts = 3;
    private const int numberOfProjectiles = 6;
    private const float angleSpread = 60f;

    public override void Attack()
    {
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {

        for (int i = 0; i < numberOfBursts; i++)
        {
            TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle, 
                angleSpread, numberOfProjectiles);
            
            if (i % 2 == 1)
            {
                currentAngle = endAngle;
                endAngle = startAngle;
                startAngle = currentAngle;
                angleStep *= -1;
            }
            
            for (int j = 0; j < numberOfProjectiles; j++)
            {
                
                Vector2 position = FindBulletSpawnPosition(currentAngle);

                GameObject newFire = Instantiate(fire, position, Quaternion.identity);
                newFire.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
                newFire.transform.right = newFire.transform.position - spellSpawnPoint.position;
                
                currentAngle += angleStep;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
