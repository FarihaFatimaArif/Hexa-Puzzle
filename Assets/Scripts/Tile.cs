using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    //GameObject hex;
    GameObject tile;
    [SerializeField] int tier;
    bool state;
    public GameObject TileObj
    {
        get { return this.tile; }
        set { this.tile = value; }
    } 
    public bool State
    {
        get { return state; }
        set { state = value; }
    }
    public int Tier
    {
        get { return this.tier; }
        set { tier = value; }
    }
}
