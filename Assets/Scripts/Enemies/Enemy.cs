using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PatrolSystem))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private StateMachine stateMachine;
    private PatrolSystem patrolSystem;

    void Start()
    {
        patrolSystem = GetComponent<PatrolSystem>();
        InitStateMachine();


        agent.SetDestination(patrolSystem.GetNextTarget()); //test
    }
    

    void Update()
    {
        //test

        if(agent.remainingDistance <= 0.1f)
        {
            agent.SetDestination(patrolSystem.GetNextTarget());
        }

        //end test
    }

    private void InitStateMachine()
    {
        stateMachine = new StateMachine();

        //create all states
        PatrolState patrolState = new PatrolState(this);
        ChasingState chasingState = new ChasingState(this);
        AttackState attackState = new AttackState(this);
        SearchState searchState = new SearchState(this);
        StunState stunState = new StunState(this);

        //create transitions between states

        patrolState.AddTransition(Transition.StartChasingTransition, StateID.ChasingStateID);
        patrolState.AddTransition(Transition.StunTransition, StateID.StunStateID);

        chasingState.AddTransition(Transition.StartAttackTransition, StateID.AttackStateID);
        chasingState.AddTransition(Transition.StunTransition, StateID.StunStateID);
        chasingState.AddTransition(Transition.StartSearchTransition, StateID.SearchStateID);

        attackState.AddTransition(Transition.StunTransition, StateID.StunStateID);

        searchState.AddTransition(Transition.StartPatrolTransition, StateID.PatrolStateID);
        searchState.AddTransition(Transition.StunTransition, StateID.StunStateID);

        //add states to machine 
        stateMachine.AddState(patrolState);
        stateMachine.AddState(chasingState);
        stateMachine.AddState(attackState);
        stateMachine.AddState(searchState);
        stateMachine.AddState(stunState);
    }
}
