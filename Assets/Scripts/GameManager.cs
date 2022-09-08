using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    TileController TileControllerRef;
    [SerializeField] AdSystem AdSystem;
    InputController InputControllerRef;
    public HexaGrid HexaGrifRef;
    TileSpawner tileSpawner;
    GameObject newTileRef;
    // Start is called before the first frame update
    void Start()
    {
        TileControllerRef = this.GetComponent<TileController>();
        InputControllerRef = this.GetComponent<InputController>();
        tileSpawner = this.GetComponent<TileSpawner>();
        tileSpawner.Spawn();
        InputControllerRef.InitializeInputController(TileControllerRef);
        TileControllerRef.InitializatingGrid(HexaGrifRef);
        TileControllerRef.InitializingTiles();
    }
    void SkipTile()
    {
       // AdSystem.O
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
