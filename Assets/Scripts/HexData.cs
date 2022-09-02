using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexData
{
    //Vector3 hexPosition;
    GameObject hex;
    bool occupied;
    string id;
    int index;
    Tile hexTile;
    public GameObject Hex
    {
        get { return this.hex; }
        set { this.hex = value; }
    }
    public bool Occupied
    {
        get { return this.occupied; }
        set { this.occupied = value; }
    }
    public string Id
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public int Index
    {
        get { return this.index; }
        set { this.index = value; }
    }
    public Tile HexTile
    {
        get { return this.hexTile; }
        set { this.hexTile = value; }
    }
}
