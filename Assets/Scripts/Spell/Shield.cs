using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour, ISpell
{
    [SerializeField] private GameObject shield;
    [SerializeField] private Transform shieldSpawnPoint;
    [SerializeField] private SpellInfo spellInfo;
    
    private GameInput gameInput;

    private void Start()
    {
        gameInput = GameObject.FindWithTag(Tags.T_GameInput).GetComponent<GameInput>();
    }

    public void Attack()
    {
        
    }

    public SpellInfo GetSpellInfo()
    {
        return this.spellInfo;
    }
}
