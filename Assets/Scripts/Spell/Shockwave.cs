using UnityEngine;

public class Shockwave : Spell
{
    [SerializeField] private GameObject shockwave;
    
    private const int numberOfProjectiles = 30;
    private const float angleSpread = 360f;

    public override void Attack()
    {
        TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle, 
            angleSpread, numberOfProjectiles);
        for (int j = 0; j < numberOfProjectiles; j++)
        {
            Vector2 position = FindBulletSpawnPosition(currentAngle);
            GameObject newThunder = Instantiate(shockwave, position, spellSpawnPoint.rotation);
            newThunder.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
            newThunder.transform.right = newThunder.transform.position - spellSpawnPoint.position;

            currentAngle += angleStep;
        }
    }
}
