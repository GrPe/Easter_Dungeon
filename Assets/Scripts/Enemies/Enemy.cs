using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PatrolSystem))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent agent;
    private StateMachine stateMachine;
    private PatrolSystem patrolSystem;

    [SerializeField] private float rangeOfView = 2f;
    public float RangeOfView { get => rangeOfView; }

    [SerializeField] private float attackRange = 1f;
    public float AttackRange { get => attackRange; }

    public float StunTime { get; private set; }

    [SerializeField] private float attackCooldown = 1.5f;
    public float AttackCooldown { get => attackCooldown; }

    [SerializeField] private float searchTime = 5f;
    public float SearchTime { get => searchTime; }

    [SerializeField] private float searchRange = 5f;
    public float SearchRange { get => searchRange; }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolSystem = GetComponent<PatrolSystem>();
        InitStateMachine();
    }
    

    void Update()
    {
        stateMachine.CurrentState.Act();
    }

    private void InitStateMachine()
    {
        stateMachine = new StateMachine();

        //create all states
        PatrolState patrolState = new PatrolState(this, agent);
        ChasingState chasingState = new ChasingState(this, agent);
        AttackState attackState = new AttackState(this);
        SearchState searchState = new SearchState(this, agent);
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

        //add events to states
        patrolState.OnAchiveTheTarget += GetNextTargetFromPatrolSystem;
        patrolState.OnFoundPlayer += FoundPlayer;

        chasingState.OnPlayerLost += PlayerLost;
        chasingState.OnAttack += Attack;

        attackState.OnPlayerOutOfAttackRange += PlayerOutOfAttackRange;

        searchState.OnContinuePatrol += ContinuePatrol;

        stunState.OnFinishStun += FinishStun;

        //add states to machine 
        stateMachine.AddState(patrolState);
        stateMachine.AddState(chasingState);
        stateMachine.AddState(attackState);
        stateMachine.AddState(searchState);
        stateMachine.AddState(stunState);
    }

    private Vector3 GetNextTargetFromPatrolSystem()
    {
        return patrolSystem.GetNextTarget();
    }

    private void FoundPlayer()
    {
        stateMachine.PerformTransition(Transition.StartChasingTransition);
    }

    private void PlayerLost()
    {
        stateMachine.PerformTransition(Transition.StartSearchTransition);
    }

    private void Attack()
    {
        stateMachine.PerformTransition(Transition.StartAttackTransition, true);
    }

    private void FinishStun()
    {
        stateMachine.ReturnToPreviousState();
    }

    public void PlayerOutOfAttackRange()
    {
        stateMachine.ReturnToPreviousState();
    }

    public void ContinuePatrol()
    {
        stateMachine.PerformTransition(Transition.StartPatrolTransition);
    }

    public void Stun(float time)
    {
        StunTime = time;
        stateMachine.PerformTransition(Transition.StunTransition, true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RangeOfView);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
