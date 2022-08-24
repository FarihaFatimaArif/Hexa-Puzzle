using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    int decider;
    int tile1;
    int tile2;
    [SerializeField] List<GameObject> TilePrefabs;
    [SerializeField] GameObject NewTileParent;
    // Start is called before the first frame update
    void Start()
    {
        decider = Random.Range(1, 10);
        if(decider<5)
        {
            tile1= Random.Range(1, 5);
            tile2= Random.Range(1, 5);
            // TilePrefabs[tile1 - 1].tag = "New Tile2";
            Instantiate(NewTileParent, NewTileParent.transform.position, Quaternion.identity);
            Instantiate(TilePrefabs[tile1-1], TilePrefabs[tile1 - 1].transform.position, Quaternion.identity);
            Vector3 temppos=TilePrefabs[tile2 - 1].transform.position;
            temppos.x= temppos.x + 0.87f;
            TilePrefabs[tile2 - 1].transform.position = temppos;
            Instantiate(TilePrefabs[tile2-1], TilePrefabs[tile2 - 1].transform.position, Quaternion.identity);
            NewTileParent.tag = "New Tile";
            TilePrefabs[tile1 - 1].transform.SetParent(NewTileParent.transform);
            TilePrefabs[tile2 - 1].transform.SetParent(NewTileParent.transform);
        }
        else 
        {
            tile1 = Random.Range(1, 5);
            TilePrefabs[tile1 - 1].tag = "New Tile";
            Instantiate(TilePrefabs[tile1 - 1], TilePrefabs[tile1 - 1].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
