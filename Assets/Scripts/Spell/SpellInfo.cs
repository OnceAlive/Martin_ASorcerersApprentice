using UnityEngine;

[CreateAssetMenu(menuName = "New Spell")]
public class SpellInfo : ScriptableObject
{
    public Sprite spellSprite;
    public float spellCooldown;
    public float spellDamage;
    public float spellRange;
    public AudioClip sound;
}