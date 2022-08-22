using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSystem 
{
    public void TapRotate();
    public void DragSnap();
    public void DragReturn();
}
