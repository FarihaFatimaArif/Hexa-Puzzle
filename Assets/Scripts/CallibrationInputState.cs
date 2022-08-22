using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallibrationInputState : InputState
{
   // public UnityEvent<Touch> Tap;
    public CallibrationInputState(IInputState listner, IInputSystem inputSystem): base(listner, inputSystem)
    {
    }
    public override void End(Touch touch)
    {
        //Listener.TapDetected
        //Tap.Invoke(touch);
        Listner.ChangeState(new IdleInputState(this.Listner, this.InputSystem));
    }

    public override void Move(Touch touch)
    { 
        Listner.ChangeState(new MovingInputState(this.Listner, this.InputSystem));
    }
}