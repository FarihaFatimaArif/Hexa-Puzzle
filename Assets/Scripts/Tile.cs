using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //GameObject hex;
    [SerializeField] int tier;
    bool state;
    Vector3 position;
    //snapped or not
    // Start is called before the first frame update
    void Start()
    {
       // position=
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool State
    {
        get { return state; }
        set { state = value; }
    }
     public Vector3 Position
    {
        get { return this.position; }
        set { this.position = value; }
    } 
}
