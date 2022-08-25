using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TileController TileControllerRef;
    InputController InputControllerRef;
    public HexaGrid HexaGrifRef;
    TileSpawner tileSpawner;
    GameObject newTileRef;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
       // newTileRef = GameObject.FindGameObjectWithTag("New Tile");
        TileControllerRef = this.GetComponent<TileController>();
        InputControllerRef = this.GetComponent<InputController>();
        tileSpawner = this.GetComponent<TileSpawner>();
        tileSpawner.Spawn();
        InputControllerRef.InitializeInputController(TileControllerRef);
        Debug.Log("gm");
        Debug.Log(TileControllerRef);
        TileControllerRef.Initialization(HexaGrifRef);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
