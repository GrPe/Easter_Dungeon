using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingState : State
{
    private Enemy enemy;
    private NavMeshAgent agent;

    public event Action OnPlayerLost;
    public event Action OnAttack;

    public ChasingState(Enemy enemy, NavMeshAgent agent)
    {
        StateID = StateID.ChasingStateID;
        this.enemy = enemy;
        this.agent = agent;
    }

    public override void DoBeforeEntering()
    {
        agent.SetDestination(enemy.player.transform.position);
    }

    public override void Act()
    {
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.AttackRange && 
            !enemy.playerSneaking.IsHidden)
        {
            OnAttack();
        }
        else if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.RangeOfView && 
            !enemy.playerSneaking.IsHidden)
        {
            agent.SetDestination(enemy.player.transform.position);
        }
        else
        {
            OnPlayerLost();
        }
    }
}

