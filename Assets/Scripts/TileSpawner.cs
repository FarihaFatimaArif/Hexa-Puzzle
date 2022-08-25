using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    int decider;
    int tileT1;
    int tileT2;
    GameObject tile1;
    GameObject tile2;
   // GameObject parent;
    [SerializeField] List<GameObject> TilePrefabs;
    [SerializeField] GameObject NewTileParent;
    // Start is called before the first frame update
    public void Spawn()
    {
        decider = Random.Range(1, 10);
        if(decider<5)
        {
            tileT1= Random.Range(1, 5);
            tileT2= Random.Range(1, 5);
            //tileT1.tag = "New Tile2";
           // parent=Instantiate(NewTileParent, NewTileParent.transform.position, Quaternion.identity);
            tile1=Instantiate(TilePrefabs[tileT1-1], TilePrefabs[tileT1 - 1].transform.position, Quaternion.identity);
            Vector3 temppos=TilePrefabs[tileT2 - 1].transform.position;
            temppos.x= temppos.x + 1;
            //TilePrefabs[tileT2 - 1].transform.position = temppos;
            tile2=Instantiate(TilePrefabs[tileT2-1], temppos, Quaternion.identity);
            //NewTileParent.tag = "New Tile";
            tile1.transform.SetParent(NewTileParent.transform);
            tile1.tag = "New Tile";
            tile2.transform.SetParent(NewTileParent.transform);
            tile2.tag = "New Tile";
        }
        else 
        {
            tileT1 = Random.Range(1, 5);
            // NewTileParent = Instantiate(NewTileParent, NewTileParent.transform.position, Quaternion.identity);
            tile1 =Instantiate(TilePrefabs[tileT1 - 1], TilePrefabs[tileT1 - 1].transform.position, Quaternion.identity);
            //NewTileParent.tag = "New Tile";
            tile1.tag = "New Tile";
            tile1.transform.SetParent(NewTileParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
