using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Thunder : MonoBehaviour, ISpell
{
    [SerializeField] private GameObject thunder;
    [SerializeField] private Transform thunderSpawnPoint;
    [SerializeField] private SpellInfo spellInfo;
    
    private const int numberOfProjectiles = 3;
    private const float angleSpread = 45f;
    
    public void Attack()
    {
        //GameObject newThunder = Instantiate(thunder, thunderSpawnPoint.position, thunderSpawnPoint.rotation);
        //newThunder.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
        TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle);
        for (int j = 0; j < numberOfProjectiles; j++)
        {
            Vector2 position = FindBulletSpawnPosition(currentAngle);
            GameObject newThunder = Instantiate(thunder, position, thunderSpawnPoint.rotation);
            newThunder.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
            newThunder.transform.right = newThunder.transform.position - thunderSpawnPoint.position;

            currentAngle += angleStep;
        }
    }

    public SpellInfo GetSpellInfo()
    {
        return spellInfo;
    }
    
    private void TargetConeOfInfluence(out float startAngle, out float currentAngle, out float angleStep, out float endAngle)
    {
        Vector2 targetDirection = thunderSpawnPoint.right;

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
        float x = thunderSpawnPoint.position.x + 0.1f * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = thunderSpawnPoint.position.y + 0.1f * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        return new Vector2(x, y);
    }
}
