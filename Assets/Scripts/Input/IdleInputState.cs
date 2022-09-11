using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleInputState : InputState
{
    public IdleInputState(IInputState listner, IInputSystem inputSystem) : base(listner, inputSystem)
    { 
    }
    override public void Begin(Touch touch)
    {
        if (InputSystem.DetectRay(touch))
        {

            Listner.ChangeState(new CallibrationInputState(this.Listner, this.InputSystem));
        }
    }
}
