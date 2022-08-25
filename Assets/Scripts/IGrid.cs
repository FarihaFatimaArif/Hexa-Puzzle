using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrid
{
    public Vector3? GetNearestPositionFromPoint(Vector3 position, Vector3 delta);
}