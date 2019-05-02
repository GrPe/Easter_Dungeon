using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    private Enemy enemy;

    public SearchState(Enemy enemy)
    {
        StateID = StateID.SearchStateID;
        this.enemy = enemy;
    }

    public override void Act()
    {

    }
}

