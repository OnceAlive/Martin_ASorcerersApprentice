using UnityEngine;

public class Fireball : MonoBehaviour, ISpell
{
    [SerializeField] private GameObject fireball;
    [SerializeField] private Transform fireballSpawnPoint;
    [SerializeField] private SpellInfo spellInfo;

    public void Attack()
    {
        GameObject newFireball = Instantiate(fireball, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
    }

    public SpellInfo GetSpellInfo()
    {
        return spellInfo;
    }
}