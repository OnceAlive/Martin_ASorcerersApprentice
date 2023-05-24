using UnityEngine;

public class Fireball : MonoBehaviour, ISpell
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private SpellInfo spellInfo;

    public void Attack()
    {
        GameObject newFireball = Instantiate(fireball, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
        newFireball.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
    }

    public SpellInfo GetSpellInfo()
    {
        return spellInfo;
    }
}