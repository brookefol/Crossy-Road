// CooldownCondition.cs
public class CooldownCondition : IJumpCondition
{
    private float cooldown;
    private float lastJumpTime;
    private ITimeProvider timeProvider;

    public CooldownCondition(float cooldown, ITimeProvider timeProvider)
    {
        this.cooldown = cooldown;
        this.timeProvider = timeProvider;
        lastJumpTime = -cooldown; // allow immediate first jump
    }
    public bool CanJump()
    {
        if (timeProvider.GetTime() - lastJumpTime >= cooldown)
        {
            lastJumpTime = timeProvider.GetTime();
            return true;
        }
        return false;
    }
}