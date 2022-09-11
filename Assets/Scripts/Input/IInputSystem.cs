using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputSystem 
{
    public void TapRotate(Touch touch);
    public void ReturnToPosition(Touch touch);
    public void SnapOnGrid(Touch touch);
    public bool DetectRay(Touch touch);
    public void MovingTile(Touch touch);
    void Highlighttiles(Touch touch);
    public void UnhighlightPreviousTiles();
}
