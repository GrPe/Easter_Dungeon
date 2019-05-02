using UnityEngine;

public class PatrolState : State
{
    private Enemy enemy;

    public PatrolState(Enemy enemy)
    {
        StateID = StateID.PatrolStateID;
        this.enemy = enemy;
    }

    public override void Act()
    {

    }
}
