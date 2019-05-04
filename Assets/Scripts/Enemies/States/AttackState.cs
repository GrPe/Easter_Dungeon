using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Enemy enemy;
    private float currentCooldownTime = 0f;

    public event Action OnPlayerOutOfAttackRange;

    public AttackState(Enemy enemy)
    {
        StateID = StateID.AttackStateID;
        this.enemy = enemy;
    }

    public override void DoBeforeEntering()
    {
        currentCooldownTime = 0f;
    }

    public override void Act()
    {
        currentCooldownTime -= Time.deltaTime;
        if(Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.AttackRange)
        {
            if(currentCooldownTime <= 0)
            {
                Attack();
                currentCooldownTime = enemy.AttackCooldown;
            }
        }
        else
        {
            OnPlayerOutOfAttackRange();
        }
    }

    private void Attack()
    {
        Debug.Log("I hit player");
    }
}

