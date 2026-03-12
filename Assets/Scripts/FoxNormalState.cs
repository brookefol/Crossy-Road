using UnityEngine;

public class FoxNormalState : IState
{
    
    public float getSpeed(){
        return 15;
    }
    

    public IState nextState(){
        if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                return new FoxSpeedyState(100);
            }
        return this;
    }
}
