using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float roamChangeDirectionFloat = 2f;
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private MonoBehaviour enemyType;
    [SerializeField] private float cooldownTime = 1f;

    private enum State
    {
        ROAMING,
        ATTACKING
    }

    private bool canAttack = true;
    private State state;
    private EnemyPathfinding enemyPathfinding;
    private Vector2 roamPosition;
    private float timeRoaming = 0f;

    private void Awake()
    {
        enemyPathfinding = GetComponent<EnemyPathfinding>();
        state = State.ROAMING;
    }

    private void Start()
    {
        roamPosition = GetRoamingPosition();
    }

    private void Update()
    {
        MovementStateControl();
    }

    private void MovementStateControl()
    {
        switch (state)
        {
            case State.ROAMING:
                Roaming();
                break;

            case State.ATTACKING:
                Attacking();
                break;

            default: 
                //should never be reached
                break;
        }
    }

    private void Roaming()
    {
        timeRoaming += Time.deltaTime;
        enemyPathfinding.MoveTo(roamPosition);

        if(Vector2.Distance(transform.position, Player.INSTANCE.transform.position) <= attackRange)
        {
            state = State.ATTACKING;
        }

        if(timeRoaming > roamChangeDirectionFloat)
        {
            roamPosition = GetRoamingPosition();
        }
    }

    private void Attacking()
    {
        if(canAttack)
        {
            canAttack = false;
            (enemyType as IEnemy).Shoot();
            StartCoroutine(AttackCooldownRoutine());
        }
    }

    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(cooldownTime);
        canAttack = true;
    }

    private Vector2 GetRoamingPosition()
    {
        timeRoaming = 0f;
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
