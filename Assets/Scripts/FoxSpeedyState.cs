using UnityEngine;

public class FoxSpeedyState : IState
{
    public int time;
    public FoxSpeedyState(int t){
         time = t;
    }
    public float getSpeed(){
        return 50;
    }    
    public IState nextState(){
        if (time >= 0)
            {
                return new FoxSpeedyState(--time);
            }
        return new FoxNormalState();
    }
}
