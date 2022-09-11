using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputState
{

    protected IInputState Listner;
    protected IInputSystem InputSystem;
    public InputState(IInputState listner, IInputSystem inputSystem)
    {
        InputSystem = inputSystem;
        Listner = listner;
    }
    public virtual void Begin(Touch touch)
    {

    }
    public virtual void Move(Touch touch)
    {

    }
    public virtual void End(Touch touch)
    {

    }
 
}
