using UnityEngine;

public class Shockwave : MonoBehaviour, ISpell
{
    [SerializeField] private GameObject shockwave;
    [SerializeField] private Transform shockwaveSpawnPoint;
    [SerializeField] private SpellInfo spellInfo;
    
    private const int numberOfProjectiles = 30;
    private const float angleSpread = 360f;
    
    public void Attack()
    {
        TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle);
        for (int j = 0; j < numberOfProjectiles; j++)
        {
            Vector2 position = FindBulletSpawnPosition(currentAngle);
            GameObject newThunder = Instantiate(shockwave, position, shockwaveSpawnPoint.rotation);
            newThunder.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
            newThunder.transform.right = newThunder.transform.position - shockwaveSpawnPoint.position;

            currentAngle += angleStep;
        }
    }

    public SpellInfo GetSpellInfo()
    {
        return spellInfo;
    }
    
    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
    {
        Vector2 targetDirection = shockwaveSpawnPoint.right;

        float targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        startAngle = targetAngle;
        endAngle = targetAngle;
        currentAngle = targetAngle;
        float halfAngleSpread = 0f;
        angleStep = 0f;

        if (angleSpread != 0)
        {
            angleStep = angleSpread / (numberOfProjectiles - 1);
            halfAngleSpread = angleSpread / 2;
            startAngle = targetAngle - halfAngleSpread;
            endAngle = targetAngle + halfAngleSpread;
            currentAngle = startAngle;
        }
    }
    
    private Vector2 FindBulletSpawnPosition(float currentAngle)
    {
        float x = shockwaveSpawnPoint.position.x + 0.1f * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = shockwaveSpawnPoint.position.y + 0.1f * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        return new Vector2(x, y);
    }
}
