using UnityEngine;

public class FoxSpeedyState : State
{
    public int time;
    public FoxSpeedyState(int t){
         time = t;
    }
    public override float getSpeed(){
        return 50;
    }    
    public override State nextState(){
        if (time >= 0)
            {
                return new FoxSpeedyState(--time);
            }
        return new FoxNormalState();
    }
}
