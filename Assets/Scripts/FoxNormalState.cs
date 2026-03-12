using UnityEngine;

public class FoxNormalState : IState
{
    public bool isShiftKeyPressed = false;

    public float getSpeed(){
        return 15;
    }
    

    public IState nextState(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
        isShiftKeyPressed = true;
    }
        if (isShiftKeyPressed)
            {
                return new FoxSpeedyState(100);
            }
        return this;
    }
}
