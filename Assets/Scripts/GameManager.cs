using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TileController TileControllerRef;
    InputController InputControllerRef;
    public HexaGrid HexaGrifRef;
    GameObject newTileRef;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        newTileRef = GameObject.FindGameObjectWithTag("New Tile");
        TileControllerRef = newTileRef.GetComponent<TileController>();
        InputControllerRef = newTileRef.GetComponent<InputController>();
        InputControllerRef.InitializeInputController(TileControllerRef);
        TileControllerRef.InitializeIGrid(HexaGrifRef);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
