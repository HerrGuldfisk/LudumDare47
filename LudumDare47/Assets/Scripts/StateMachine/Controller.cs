using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    private BaseState currentState;
    public BaseState CurrentState
    {
        get { return currentState; }
    }

    public readonly ExampleState exampleState = new ExampleState();
    //add all states here

    private void Start()
    {
        TransitionToState(exampleState);
    }

    private void Update()
    {
        currentState.Update(this);
    }

    public void TransitionToState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
