using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TileController TileControllerRef;
    public InputController InputControllerRef;
    public HexaGrid HexaGrifRef;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        InputControllerRef.InitializeInputController(TileControllerRef);
        TileControllerRef.InitializeIGrid(HexaGrifRef);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
