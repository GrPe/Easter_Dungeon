using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private List<State> states;
    public StateID CurrentStateID { get; private set; }
    public State CurrentState { get; private set; }

    public StateMachine()
    {
        states = new List<State>();
    }

    public void AddState(State s)
    {

        // Check for Null reference before deleting
        if (s == null)
        {
            Debug.LogError("FSM ERROR: Null reference is not allowed");
        }

        // First State inserted is also the Initial state,
        //   the state the machine is in when the simulation begins
        if (states.Count == 0)
        {
            states.Add(s);
            CurrentState = s;
            CurrentStateID = s.StateID;
            CurrentState.DoBeforeEntering();
            return;
        }

        // Add the state to the List if it's not inside it
        foreach (State state in states)
        {
            if (state.StateID == s.StateID)
            {
                Debug.LogError($"FSM ERROR: Impossible to add state {s.StateID.ToString()} because state has already been added");
                return;
            }
        }
        states.Add(s);
    }


    public void DeleteState(StateID id)
    {
        // Check for NullState before deleting
        if (id == StateID.NullStateID)
        {
            Debug.LogError("FSM ERROR: NullStateID is not allowed for a real state");
            return;
        }

        // Search the List and delete the state if it's inside it
        foreach (State state in states)
        {
            if (state.StateID == id)
            {
                states.Remove(state);
                return;
            }
        }
        Debug.LogError($"FSM ERROR: Impossible to delete state {id.ToString()}. It was not on the list of states");
    }

    public void PerformTransition(Transition trans)
    {
        // Check for NullTransition before changing the current state
        if (trans == Transition.NullTransition)
        {
            Debug.LogError("FSM ERROR: NullTransition is not allowed for a real transition");
            return;
        }

        // Check if the currentState has the transition passed as argument
        StateID id = CurrentState.GetOutputState(trans);
        if (id == StateID.NullStateID)
        {
            Debug.LogError($"FSM ERROR: State {CurrentStateID.ToString()} does not have a target state " +
                           $" for transition {trans.ToString()}");
            return;
        }

        // Update the currentStateID and currentState		
        CurrentStateID = id;
        foreach (State state in states)
        {
            if (state.StateID == CurrentStateID)
            {
                // Do the post processing of the state before setting the new one
                CurrentState.DoBeforeLeaving();

                CurrentState = state;

                // Reset the state to its desired condition before it can reason or act
                CurrentState.DoBeforeEntering();
                break;
            }
        }

    }
}