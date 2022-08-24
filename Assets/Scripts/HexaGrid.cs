using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaGrid : MonoBehaviour, IGrid
{
    [SerializeField] GameObject Tile;
    int width = 5;
    int height = 5;
    float xOffset = 1f;
    float yOffset = 0.86f;
    float xPos;
    float yPos;
    Vector3 pos;

    GameObject tileGenerated;

    public Dictionary<Vector3, GameObject> tiles = new Dictionary<Vector3, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        tiles.Clear();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (y % 2 == 0)
                {
                    xPos = x * xOffset;
                    yPos = y * yOffset;
                    pos.x = xPos;
                    pos.y = yPos;
                    pos.z = 0;
                    tileGenerated = (GameObject)Instantiate(Tile, pos, Quaternion.identity);
                    tileGenerated.name = "Hex_" + x + "_" + y;
                    tileGenerated.transform.SetParent(this.transform);
                    tiles.Add(pos, tileGenerated);
                }
                else if (x<width-1)
                {
                    xPos = x * xOffset;
                    xPos += xOffset / 2f;
                    yPos = y * yOffset;
                    pos.x = xPos;
                    pos.y = yPos;
                    pos.z = 0;
                    tileGenerated = (GameObject)Instantiate(Tile, pos, Quaternion.identity);
                    tileGenerated.name = "Hex_" + x + "_" + y;
                    tileGenerated.transform.SetParent(this.transform);
                    tiles.Add(pos, tileGenerated);
                }

            }
        }
    }

    public Vector3? GetNearestPositionFromPoint(Vector3 position)
    {
        foreach(var pair in tiles)
        {
            float distance = Vector3.Distance(pair.Key, position);
            if (distance < 0.5f)
            {
                return pair.Key;
            }
        }

        return null;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2? snapPosition = GetNearestPositionFromPoint(Vector2.zero);
        //if (snapPosition.HasValue)
        //{
        //    Vector2 snap = snapPosition.Value;
        //}
    }
}
