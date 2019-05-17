using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Enemy enemy;
    private float currentCooldownTime = 0f;
    private Player player;

    public event Action OnPlayerOutOfAttackRange;

    public AttackState(Enemy enemy)
    {
        StateID = StateID.AttackStateID;
        this.enemy = enemy;
        this.player = enemy.player.GetComponent<Player>();
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
        var obj = GameObject.Instantiate(enemy.attackParticle, player.transform.position, Quaternion.identity);
        GameObject.Destroy(obj, 1f);
        player?.DealDamage();
    }
}

