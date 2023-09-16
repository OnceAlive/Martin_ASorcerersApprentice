using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldownbar : MonoBehaviour
{
    
    private Slider cooldownbarSlider;
    [SerializeField] private bool isAttack = false;
    [SerializeField] private ActiveSpell activeSpell;
    // Start is called before the first frame update
    void Start()
    {
        cooldownbarSlider = GetComponent<Slider>();
        if (!isAttack)
        {
            GameObject.FindGameObjectWithTag(Tags.T_Player).GetComponent<Player>().OnDashStarted += HandleDashStarted;
        }
        else
        {
           activeSpell.OnAttackStarted += HandleAttackStarted;
        }
    }
    
    private void HandleDashStarted(object sender, float dashTime)
    {
        Debug.Log("Dash started");
        StartCoroutine(StartCooldown(dashTime));
    }
    
    private void HandleAttackStarted(object sender, float attackTime)
    {
        Debug.Log("Attack started");
        StartCoroutine(StartCooldown(attackTime));
    }
    
    private IEnumerator StartCooldown(float cooldownTime)
    {
        float time = 0f;
        while (time < cooldownTime)
        {
            time += Time.deltaTime;
            cooldownbarSlider.value = time / cooldownTime;
            yield return null;
        }
    }
}
