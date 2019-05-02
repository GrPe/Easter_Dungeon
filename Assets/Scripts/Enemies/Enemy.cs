using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    private StateMachine stateMachine;

    void Start()
    {
        InitStateMachine();
    }
    

    void Update()
    {
        
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
