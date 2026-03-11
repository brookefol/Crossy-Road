using UnityEngine;

public class FoxNormalState : State
{
    
    public override float getSpeed(){
        return 15;
    }
    

    public override State nextState(){
        if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                return new FoxSpeedyState(100);
            }
        return this;
    }
}
