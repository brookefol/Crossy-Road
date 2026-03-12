using UnityEngine;

public interface IState
{
    public abstract float getSpeed();
    public abstract IState nextState();
}
