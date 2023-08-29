using System.Collections;
using UnityEngine;

public class ActiveSpell : MonoBehaviour
{
    public static ActiveSpell INSTANCE;

    [SerializeField] private MonoBehaviour currentActiveSpell;
    
    private bool isAttacking = false;
    private float timeBetweenAttacks;
    private GameInput gameInput;

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
        gameInput = GameObject.FindGameObjectWithTag(Tags.T_GameInput).GetComponent<GameInput>();
        gameInput.Attack.performed += _ => Attack();
    }

    public void NewSpell(MonoBehaviour newSpell)
    {
        currentActiveSpell = newSpell;
        AttackCooldown();
        timeBetweenAttacks = (currentActiveSpell as Spell).GetSpellInfo().spellCooldown;
    }

    private IEnumerator TimeBetweenAttacksRoutine()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    private void Attack()
    {
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