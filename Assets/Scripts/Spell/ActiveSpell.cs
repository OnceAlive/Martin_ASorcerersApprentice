using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActiveSpell : MonoBehaviour
{
    public static ActiveSpell INSTANCE;
    
    [SerializeField] private GameObject[] spells;
    private int activeSlotIndexNumber = 0;

    [SerializeField] private MonoBehaviour currentActiveSpell;
    public event EventHandler<float> OnAttackStarted;
    public event EventHandler<Spell> OnSpellChanged; 
    
    private bool isAttacking = false;
    private float timeBetweenAttacks;

    private float spellIndex;
    
    private void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }
        
        timeBetweenAttacks = (currentActiveSpell as Spell).GetSpellInfo().spellCooldown;
    }
    
    private void Start()
    {
        AttackCooldown();
    }

    public void OnSpellChangeRequest(InputAction.CallbackContext context)
    {
        spellIndex = context.ReadValue<float>() - 1;
        ToggleActiveSlot((int) spellIndex);
    }
    
    public void ToggleActiveSlot(int number)
    {
        ChangeActiveSpell((MonoBehaviour)spells[number].GetComponent(typeof(MonoBehaviour)));
    }
    
    private void ChangeActiveSpell(MonoBehaviour spell)
    {
        NewSpell(spell);
    }

    public void NewSpell(MonoBehaviour newSpell)
    {
        EventHandler<Spell> handler = OnSpellChanged;
        handler?.Invoke(this, newSpell as Spell);
        currentActiveSpell = newSpell;
        AttackCooldown();
        timeBetweenAttacks = (currentActiveSpell as Spell).GetSpellInfo().spellCooldown;
    }

    private IEnumerator TimeBetweenAttacksRoutine()
    {
        EventHandler<float> handler = OnAttackStarted;
        handler?.Invoke(this, timeBetweenAttacks);
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    public void Attack()
    {
        if (PauseMenu.IsPaused)
        {
            return;
        }
        
        if(!isAttacking)
        {
            AttackCooldown();

            (currentActiveSpell as Spell).Attack();
        }
    }

    private void AttackCooldown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }
}