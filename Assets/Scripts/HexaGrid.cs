using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HexaGrid : MonoBehaviour, IGrid
{
    [SerializeField] GameObject Tile;
    [SerializeField] int Width = 5;
    [SerializeField] int Height = 5;
    float xOffset = 1f;
    float yOffset = 0.86f;
    float xPos;
    float yPos;
    bool once = false;
    GameObject tileGenerated;

    public Dictionary<Vector3, GameObject> tiles = new Dictionary<Vector3, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Vector3 tilePosition;

        tiles.Clear();
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (y % 2 == 0)
                {
                    xPos = x * xOffset;
                    yPos = y * yOffset;
                    tilePosition.x = xPos;
                    tilePosition.y = yPos;
                    tilePosition.z = 0;
                    if (!once)
                    {
                        tileGenerated = (GameObject)Instantiate(Tile, tilePosition, Quaternion.identity);
                    }
                    else
                    {
                        tileGenerated = (GameObject)Instantiate(tileGenerated, tilePosition, Quaternion.identity);
                    }
                    tileGenerated.name = "Hex_" + x + "_" + y;
                    tileGenerated.transform.SetParent(this.transform);
                    tiles.Add(tilePosition, tileGenerated);
                }
                else if (x<Width-1)
                {
                    xPos = x * xOffset;
                    xPos += xOffset / 2f;
                    yPos = y * yOffset;
                    tilePosition.x = xPos;
                    tilePosition.y = yPos;
                    tilePosition.z = 0;
                    tileGenerated = (GameObject)Instantiate(Tile, tilePosition, Quaternion.identity);
                    tileGenerated.name = "Hex_" + x + "_" + y;
                    tileGenerated.transform.SetParent(this.transform);
                    tiles.Add(tilePosition, tileGenerated);
                }

            }
        }
    }

    public Vector3? GetNearestPositionFromPoint(Vector3 position, Vector3 delta)
    {
        float distance;
        foreach (var pair in tiles)
        {
             distance = Vector3.Distance(pair.Key, position);
            if (distance < 0.5f)
            {
                foreach (var pair2 in tiles)
                {
                    distance = Vector3.Distance(pair2.Key, position+delta);
                    if (distance < 0.5f)
                    {
                        return pair.Key;
                    }
                }
            }
        }

        return null;
    }

    public GameObject FindTile(Vector3 pos)
    {
        Debug.Log("in findtile");
        Debug.Log(pos);
        GameObject tile = tiles[pos];
        return tile;
    }
}
