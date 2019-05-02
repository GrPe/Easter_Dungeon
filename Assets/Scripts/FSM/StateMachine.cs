using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private List<State> states;
    private Stack<State> stateStack;

    public State CurrentState { get => stateStack.Peek(); }
    public StateID CurrentStateID { get => CurrentState.StateID; }

    public StateMachine()
    {
        states = new List<State>();
        stateStack = new Stack<State>();
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
            stateStack.Push(s);
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
        foreach (State state in states)
        {
            if (state.StateID == id)
            {
                // Do the post processing of the state before setting the new one
                CurrentState.DoBeforeLeaving();

                stateStack.Pop();
                stateStack.Push(state);

                // Reset the state to its desired condition before it can reason or act
                CurrentState.DoBeforeEntering();
                break;
            }
        }

    }

    public void ReturnToPreviousState()
    {
        if(CurrentState.StateID == StateID.NullStateID)
        {
            Debug.LogError("FSM doesn't contain any state");
            return;
        }

        if (stateStack.Count <= 1)
        {
            Debug.LogError("FSM cannot return to the previous state.");
            return;
        }

        stateStack.Pop();
    }
}