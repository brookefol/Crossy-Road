using UnityEngine;

public abstract class State
{
    public abstract float getSpeed();
    public abstract State nextState();
}
