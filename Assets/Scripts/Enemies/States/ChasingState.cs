using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    private Enemy enemy;

    public ChasingState(Enemy enemy)
    {
        StateID = StateID.ChasingStateID;
        this.enemy = enemy;
    }

    public override void Act()
    {

    }
}

