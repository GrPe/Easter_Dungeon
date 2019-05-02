using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private Enemy enemy;

    public AttackState(Enemy enemy)
    {
        StateID = StateID.AttackStateID;
        this.enemy = enemy;
    }

    public override void Act()
    {

    }
}

