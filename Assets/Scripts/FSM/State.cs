using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    public StateID StateID { get; protected set; }

    public void AddTransition(Transition trans, StateID id)
    {
        // Check if anyone of the args is invalid
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed for a real transition");
            return;
        }

        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSMState ERROR: NullStateID is not allowed for a real ID");
            return;
        }

        // Since this is a Deterministic FSM,
        //   check if the current transition was already inside the map
        if (map.ContainsKey(trans))
        {
            Debug.LogError($"FSMState ERROR: State {StateID.ToString()} already has transition {trans.ToString()} " +
                           "Impossible to assign to another state");
            return;
        }

        map.Add(trans, id);
    }

    public void DeleteTransition(Transition trans)
    {
        // Check for NullTransition
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSMState ERROR: NullTransition is not allowed");
            return;
        }

        // Check if the pair is inside the map before deleting
        if (map.ContainsKey(trans))
        {
            map.Remove(trans);
            return;
        }
        Debug.LogError($"FSMState ERROR: Transition {trans.ToString()} passed to {StateID.ToString()}" +
                       " was not on the state's transition list");
    }

    public StateID GetOutputState(Transition trans)
    {
        // Check if the map has this transition
        if (map.ContainsKey(trans))
        {
            return map[trans];
        }
        return StateID.NullStateID;
    }

    public virtual void DoBeforeEntering() { }

    public virtual void DoBeforeLeaving() { }

    public virtual void Act() { }

    public virtual void OnCollision2DEnter(Collision2D collision) { }

    public virtual void OnCollision2DStay(Collision2D collision) { }

    public virtual void OnTrigger2DEnter(Collider2D collider) { }

    public virtual void OnTrigger2DStay(Collider2D collider) { }

    public virtual void OnTrigger3DEnter(Collider collider) { }

    public virtual void OnTrigger3DStay(Collider collider) { }
}