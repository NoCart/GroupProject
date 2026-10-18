using UnityEngine;

public class StateMachine : MonoBehaviour
{

    public IState initialState;

    IState state;
    void Start()
    {
        state = initialState;
        state.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        state.StateUpdate();
    }

    private void FixedUpdate()
    {
        state.StateFixedUpdate();
    }

    void TransitionTo(IState newState)
    {
        state.Exit();
        state = newState;
        state.Enter();
    }
}
