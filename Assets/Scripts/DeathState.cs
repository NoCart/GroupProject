using UnityEngine;

public class DeathState : PlayerState, IState
{
    public void Enter()
    {
        rb.linearVelocity = Vector3.zero;
    }
    
    
}
