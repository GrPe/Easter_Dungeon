using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    private Enemy enemy;
    private float stunTime = 0f;

    public event Action OnFinishStun;

    public StunState(Enemy enemy)
    {
        StateID = StateID.StunStateID;
        this.enemy = enemy;
    }

    public override void OnCollision2DEnter(Collision2D collision)
    {
        stunTime = enemy.StunTime;
    }

    public override void Act()
    {
        stunTime -= Time.deltaTime;
        if (stunTime <= 0) OnFinishStun();
    }
}

