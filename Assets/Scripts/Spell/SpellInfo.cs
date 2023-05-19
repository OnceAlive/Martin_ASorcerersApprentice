using UnityEngine;

[CreateAssetMenu(menuName = "New Spell")]
public class SpellInfo : ScriptableObject
{
    public GameObject spellPrefab;
    public float spellCooldown;
    public float spellDamage;
}