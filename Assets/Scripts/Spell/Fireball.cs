using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Fireball : Spell
{
    [SerializeField] private GameObject fireball;
   
    public override void Attack()
    {
        GameObject newFireball = Instantiate(fireball, spellSpawnPoint.position, spellSpawnPoint.rotation);
        newFireball.GetComponent<Projectile>().UpdateProjectileRange(spellInfo.spellRange);
    }
}