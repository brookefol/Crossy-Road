// Brooke Foley
// JumpConditionTests.cs

// Testing strategy: These tests target the pure logic of GroundedCondition and CooldownCondition
// through injected interfaces, avoiding any dependency on Unity's runtime or sealed classes like
// Rigidbody. I chose to test boundary values (exactly at threshold, just above/below) rather than
// arbitrary values, since the correctness of these conditions hinges on precise comparisons.
// I excluded tests for FoxJump itself since its Jump() method is private and triggered via static
// GameEvents — testing that would couple tests to Unity's event system and make the suite brittle.
// The tradeoff is that integration between FoxJump and the conditions is untested here, but each
// piece is verified independently, which is more maintainable.


using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class JumpConditionTests
{
    // ─── GroundedCondition 

    [Test]
    public void GroundedCondition_CanJump_WhenVelocityIsZero()
    {
        var velocity = Substitute.For<IVelocityProvider>();
        velocity.GetVerticalVelocity().Returns(0f);

        var condition = new GroundedCondition(velocity);

        Assert.IsTrue(condition.CanJump());
    }

    [Test]
    public void GroundedCondition_CannotJump_WhenVelocityIsHigh()
    {
        var velocity = Substitute.For<IVelocityProvider>();
        velocity.GetVerticalVelocity().Returns(5f);

        var condition = new GroundedCondition(velocity);

        Assert.IsFalse(condition.CanJump());
    }

    [Test]
    public void GroundedCondition_CannotJump_WhenFalling()
    {
        var velocity = Substitute.For<IVelocityProvider>();
        velocity.GetVerticalVelocity().Returns(-3f); // falling down

        var condition = new GroundedCondition(velocity);

        Assert.IsFalse(condition.CanJump());
    }

    [Test]
    public void GroundedCondition_CanJump_AtExactThreshold()
    {
        var velocity = Substitute.For<IVelocityProvider>();
        velocity.GetVerticalVelocity().Returns(0.009f); // just under 0.01f

        var condition = new GroundedCondition(velocity);

        Assert.IsTrue(condition.CanJump());
    }

    // ─── CooldownCondition ───────────────────────────────────────────

    [Test]
    public void CooldownCondition_CanJump_OnFirstCall()
    {
        var time = Substitute.For<ITimeProvider>();
        time.GetTime().Returns(0f);

        var condition = new CooldownCondition(1f, time);

        Assert.IsTrue(condition.CanJump());
    }

    [Test]
    public void CooldownCondition_CannotJump_BeforeCooldownExpires()
    {
        var time = Substitute.For<ITimeProvider>();
        time.GetTime().Returns(0f);

        var condition = new CooldownCondition(1f, time);
        condition.CanJump(); // first jump at t=0

        time.GetTime().Returns(0.5f); // only 0.5s later, cooldown is 1s

        Assert.IsFalse(condition.CanJump());
    }

    [Test]
    public void CooldownCondition_CanJump_AfterCooldownExpires()
    {
        var time = Substitute.For<ITimeProvider>();
        time.GetTime().Returns(0f);

        var condition = new CooldownCondition(1f, time);
        condition.CanJump(); // first jump at t=0

        time.GetTime().Returns(1f); // exactly 1s later

        Assert.IsTrue(condition.CanJump());
    }

    [Test]
    public void CooldownCondition_ResetsTimer_AfterSuccessfulJump()
    {
        var time = Substitute.For<ITimeProvider>();
        time.GetTime().Returns(0f);

        var condition = new CooldownCondition(1f, time);
        condition.CanJump();        // jump at t=0

        time.GetTime().Returns(1f);
        condition.CanJump();        // jump at t=1, resets timer

        time.GetTime().Returns(1.5f); // only 0.5s after second jump

        Assert.IsFalse(condition.CanJump());
    }
}