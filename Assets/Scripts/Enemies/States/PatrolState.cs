using UnityEngine;
using System;
using UnityEngine.AI;

public class PatrolState : State
{
    private Enemy enemy;
    private NavMeshAgent playerAgent;
    
    public event Func<Vector3> OnAchiveTheTarget;
    public event Action OnFoundPlayer;

    public PatrolState(Enemy enemy, NavMeshAgent agent)
    {
        StateID = StateID.PatrolStateID;
        this.enemy = enemy;
        this.playerAgent = agent;
    }

    public override void DoBeforeEntering()
    {
        playerAgent.SetDestination(OnAchiveTheTarget());
    }

    public override void Act()
    {
        if (playerAgent.remainingDistance <= 0.1f)
        {
            playerAgent.SetDestination(OnAchiveTheTarget());
        }

        if (enemy.RangeOfView >= Vector3.Distance(enemy.transform.position, enemy.player.transform.position) &&
            !enemy.playerSneaking.IsHidden)
        {

            RaycastHit hit;
            Vector3 direction = enemy.player.transform.position - enemy.transform.position;

            if (Physics.Raycast(enemy.transform.position, direction.normalized, out hit, enemy.RangeOfView))
            {
                if(hit.collider.tag == "Player")
                {
                    OnFoundPlayer();
                }
            }
        }
    }
}
