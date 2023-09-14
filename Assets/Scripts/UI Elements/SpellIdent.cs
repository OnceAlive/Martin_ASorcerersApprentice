using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellIdent : MonoBehaviour
{
    private Image spellImage;
    [SerializeField] private ActiveSpell activeSpell;
    
    // Start is called before the first frame update
    void Start()
    {
        spellImage = GetComponent<Image>();
        activeSpell.OnSpellChanged += HandleSpellChanged;
        
    }

    private void HandleSpellChanged(object sender, Spell spell)
    {
        spellImage.sprite = spell.GetSpellInfo().spellSprite;
    }
}
