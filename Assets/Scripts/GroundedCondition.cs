// GroundedCondition.cs
using UnityEngine;
public class GroundedCondition : IJumpCondition
{
    private IVelocityProvider velocityProvider;
    public GroundedCondition(IVelocityProvider velocityProvider)
    {
        this.velocityProvider = velocityProvider;
    }
    public bool CanJump()
    {
        return Mathf.Abs(velocityProvider.GetVerticalVelocity()) < 0.01f;
    }
}