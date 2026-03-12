// Siena Zerillo

using NUnit.Framework;
using NSubstitute;

public class StateTests
{
    private IState state;

    [Test]
    public void DoesNormalStateNextStateWorkNoKeysPressed()
    {
        state = new FoxNormalState();
        state = state.nextState();
        Assert.IsInstanceOf<FoxNormalState>(state);
    }

    [Test]
    public void DoesNormalStateNextStateWorkShiftPressed()
    {
        state = new FoxNormalState();
        FoxNormalState statenormal = (FoxNormalState)(state);
        statenormal.isShiftKeyPressed = true;
        state = statenormal;
        state = state.nextState();
        Assert.IsInstanceOf<FoxSpeedyState>(state);
    }

    [Test]
    public void DoesSpeedyStateNextStateTimeZeroWork(){
        state = new FoxSpeedyState(0);
        state = state.nextState();
        Assert.IsInstanceOf<FoxNormalState>(state);
    }
    [Test]
    public void DoesSpeedyStateNextStateMakeANewSpeedyStateWithCorrectTime(){
        state = new FoxSpeedyState(3);
        state = state.nextState();
        FoxSpeedyState speedyState = (FoxSpeedyState)(state);
        Assert.AreEqual(2, speedyState.time);
    }
    [Test]
    public void DoesSpeedyStateNextStateTimeAboveZeroMakeAnotherSpeedyState(){
        state = new FoxSpeedyState(3);
        state = state.nextState();
        Assert.IsInstanceOf<FoxSpeedyState>(state);
    }
    [Test]
    public void IsSpeedyStateFasterThanNormalState(){
        IState normalState = new FoxNormalState();
        IState speedyState = new FoxSpeedyState(30);
        Assert.Greater(speedyState.getSpeed(), normalState.getSpeed());
    }
}
