using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : State
{
    private Enemy enemy;
    private NavMeshAgent agent;
    private float currentSearchTime = 0f;
    private Vector3 targetPosition;

    public event Action OnContinuePatrol;

    public SearchState(Enemy enemy, NavMeshAgent agent)
    {
        StateID = StateID.SearchStateID;
        this.enemy = enemy;
        this.agent = agent;
    }

    public override void DoBeforeEntering()
    {
        currentSearchTime = enemy.SearchTime;
        targetPosition = UnityEngine.Random.insideUnitCircle * enemy.SearchRange;
        agent.SetDestination(targetPosition);
    }

    public override void Act()
    {
        currentSearchTime -= Time.deltaTime;

        if(agent.remainingDistance < 0.1)
        {
            agent.SetDestination(UnityEngine.Random.insideUnitSphere * enemy.SearchRange);
        }

        if(Vector3.Distance(enemy.transform.position, enemy.player.transform.position) < enemy.RangeOfView && 
            !enemy.playerSneaking.IsHidden)
        {
            OnContinuePatrol();
        }

        if (currentSearchTime <= 0) OnContinuePatrol();
    }
}

