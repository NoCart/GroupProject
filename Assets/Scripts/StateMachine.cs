using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{


    public enum enumState { Idle, Run };
    public enumState InitialState;

    public Text debugText;

    IState state;
    void Start()
    {
        switch (InitialState)
        {
            case enumState.Idle: { state = GetComponent<IdleState>(); break; }
        }
        print(state);
        state.Enter();
    }

    // Update is called once per frame
    private void Update()
    {
        state.StateUpdate();
    }

    private void FixedUpdate()
    {
        state.StateFixedUpdate();
    }

    public void TransitionTo(IState newState)
    {
        state.Exit();
        state = newState;
        state.Enter();
        debugText.text = state.ToString();
    }
}
