using System.Collections;
using UnityEngine;

public class ActiveSpell : MonoBehaviour
{
    public static ActiveSpell INSTANCE;

    [SerializeField] private MonoBehaviour currentActiveSpell;

    private PlayerInput playerInput;
    private bool attackButtonPressed;
    private bool isAttacking = false;
    private float timeBetweenAttacks;

    private void Awake()
    {
        if(INSTANCE == null)
        {
            INSTANCE = this;
        }

        playerInput = new PlayerInput();
        timeBetweenAttacks = (currentActiveSpell as ISpell).GetSpellInfo().spellCooldown;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Start()
    {
        playerInput.Combat.Attack.started += _ => attackButtonPressed = true;
        playerInput.Combat.Attack.canceled += _ => attackButtonPressed = false;

        AttackCooldown();
    }

    private void Update()
    {
        Attack();
    }

    public void NewSpell(MonoBehaviour newSpell)
    {
        currentActiveSpell = newSpell;
        AttackCooldown();
        timeBetweenAttacks += (currentActiveSpell as ISpell).GetSpellInfo().spellCooldown;
    }

    private void AttackCooldown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }

    private IEnumerator TimeBetweenAttacksRoutine()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    private void Attack()
    {
        if(attackButtonPressed && !isAttacking)
        {
            AttackCooldown();

            (currentActiveSpell as ISpell).Attack();
        }
    }
}