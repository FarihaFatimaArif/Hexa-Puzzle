using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    int decider;
    int tileT1;
    int tileT2;
    [SerializeField] Vector3 InitialPos;
    GameObject tile1;
    GameObject tile2;
   // GameObject parent;
    [SerializeField] List<GameObject> TilePrefabs;
    [SerializeField] GameObject NewTileParent;
    // Start is called before the first frame update
    public void Spawn()
    {
        //Debug.Log("ssss");
        InitialPos = new Vector3(1.5f, -4, 0);
        decider = Random.Range(1, 10);
        if(decider<5)
        {
            tileT1= Random.Range(1, 5);
            tileT2= Random.Range(1, 5);
            tile1=Instantiate(TilePrefabs[tileT1-1], InitialPos, Quaternion.identity);
           // InitialPos = TilePrefabs[tileT2 - 1].transform.position;
            InitialPos.x= InitialPos.x + 1;
            //TilePrefabs[tileT2 - 1].transform.position = temppos;
            tile2=Instantiate(TilePrefabs[tileT2-1], InitialPos, Quaternion.identity);
            //NewTileParent.tag = "New Tile";
            tile1.transform.SetParent(NewTileParent.transform);
            tile1.tag = "New Tile";
            tile2.transform.SetParent(NewTileParent.transform);
            tile2.tag = "New Tile";
            tile1.GetComponent<SpriteRenderer>().sortingOrder = 2;
            tile2.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
        else
        {
            InitialPos.x = InitialPos.x + 0.5f;
            tileT1 = Random.Range(1, 5);
            // NewTileParent = Instantiate(NewTileParent, NewTileParent.transform.position, Quaternion.identity);
            tile1 =Instantiate(TilePrefabs[tileT1 - 1], InitialPos, Quaternion.identity);
            //NewTileParent.tag = "New Tile";
            tile1.tag = "New Tile";
            tile1.transform.SetParent(NewTileParent.transform);
            tile1.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
