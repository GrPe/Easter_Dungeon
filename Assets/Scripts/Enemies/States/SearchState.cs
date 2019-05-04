using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    private Enemy enemy;
    private float currentSearchTime = 0f;

    public event Action OnContinuePatrol;

    public SearchState(Enemy enemy)
    {
        StateID = StateID.SearchStateID;
        this.enemy = enemy;
    }

    public override void DoBeforeEntering()
    {
        currentSearchTime = enemy.SearchTime;
    }

    public override void Act()
    {
        currentSearchTime -= Time.deltaTime;

        //do something

        if (currentSearchTime <= 0) OnContinuePatrol();
    }
}

