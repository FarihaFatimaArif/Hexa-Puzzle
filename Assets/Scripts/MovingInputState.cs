using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingInputState : InputState
{
    //public UnityEvent<Touch> DragMove;
    //public UnityEvent<Touch> DragEnd;
    public MovingInputState(IInputState listner, IInputSystem inputSystem) : base(listner, inputSystem)
    {
    }
    public override void Move(Touch touch)
    {
        //Drag Move
        //DragMove.Invoke(touch);
        // Debug.LogError($"");
        InputSystem.MovingTile(touch);
    }
    public override void End(Touch touch)
    {
        //Drag End
        //DragMove.Invoke(touch);
        InputSystem.SnapOnGrid(touch);
       // InputSystem.ReturnToPosition(touch);
        //InputSystem.SnapOnGrid(touch);
        Listner.ChangeState(new IdleInputState(this.Listner, this.InputSystem));

    }
}
