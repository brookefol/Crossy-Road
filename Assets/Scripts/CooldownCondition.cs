// CooldownCondition.cs — enforce a delay between jumps
using UnityEngine;

public class CooldownCondition : IJumpCondition
{
    private float cooldown;
    private float lastJumpTime = -Mathf.Infinity;

    public CooldownCondition(float cooldown)
    {
        this.cooldown = cooldown;
    }

    public bool CanJump()
    {
        if (Time.time - lastJumpTime >= cooldown)
        {
            lastJumpTime = Time.time;
            return true;
        }
        return false;
    }
}