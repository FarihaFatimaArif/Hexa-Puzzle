
using System.Collections.Generic;
using UnityEngine;

public interface IGrid
{
    public HexData GetNearestPositionFromPoint(Vector3 position);
    public void ResetColor(List<GameObject> temp);
    public void searching(HexData hex);
    //public GameObject FindTile(Vector3 pos);
    //public int GetChildCount(Tile);
}