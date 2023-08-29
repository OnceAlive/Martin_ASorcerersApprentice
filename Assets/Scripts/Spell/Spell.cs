using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] protected SpellInfo spellInfo;
    [SerializeField] protected Transform spellSpawnPoint;
    
    public abstract void Attack();

    public virtual SpellInfo GetSpellInfo()
    {
        return spellInfo;
    }
    
    protected void TargetConeOfInfluence(
        out float startAngle, 
        out float currentAngle, 
        out float angleStep, 
        out float endAngle, 
        float angleSpread, 
        int numberOfProjectiles)
    {
        Vector2 targetDirection = spellSpawnPoint.right;

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
    
    protected Vector2 FindBulletSpawnPosition(float currentAngle)
    {
        float x = spellSpawnPoint.position.x + 0.1f * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
        float y = spellSpawnPoint.position.y + 0.1f * Mathf.Sin(currentAngle * Mathf.Deg2Rad);

        return new Vector2(x, y);
    }
}