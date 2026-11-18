using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{


    public enum enumState { Idle, Run };
    public enumState InitialState;

    public Text debugText;

    private bool frozen = false;

    private Vector2 lastVelocity;

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
        if (frozen) { return; }
        state.StateUpdate();
    }

    private void FixedUpdate()
    {
        if (frozen) { return; }
        state.StateFixedUpdate();
    }

    public void TransitionTo(IState newState)
    {
        state.Exit();
        state = newState;
        state.Enter();
        debugText.text = state.ToString();
    }

    public void SetFrozen(bool value)
    {
        frozen = value;

        if (frozen == true)
        {
            lastVelocity = GetComponent<Rigidbody2D>().linearVelocity;
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            GetComponent<Animator>().speed = 0.0f;
        }
        else
        {
            GetComponent<Animator>().speed = 1.0f;
            GetComponent<Rigidbody2D>().linearVelocity = lastVelocity;
        }
    }
}
