using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : State
{
    private Enemy enemy;

    public StunState(Enemy enemy)
    {
        StateID = StateID.StunStateID;
        this.enemy = enemy;
    }

    public override void Act()
    {

    }
}

