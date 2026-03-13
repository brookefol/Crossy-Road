// GroundedCondition.cs — only jump when touching the ground
using UnityEngine;

public class GroundedCondition : IJumpCondition
{
    private Rigidbody rb;

    public GroundedCondition(Rigidbody rb)
    {
        this.rb = rb;
    }

    public bool CanJump()
    {
        return Mathf.Abs(rb.linearVelocity.y) < 0.01f; // near-zero vertical velocity = grounded
    }
}