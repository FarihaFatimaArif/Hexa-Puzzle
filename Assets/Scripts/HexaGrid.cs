using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaGrid : MonoBehaviour
{
    [SerializeField] GameObject Tile;
    int width = 5;
    int height = 5;
    float xOffset = 1f;
    float yOffset = 0.86f;
    float xPos;
    float yPos;
    Vector2 pos;
    GameObject tileGenerated;
    // Start is called before the first frame update
    void Start()
    {
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
                    tileGenerated = (GameObject)Instantiate(Tile, pos, Quaternion.identity);
                    tileGenerated.name = "Hex_" + x + "_" + y;
                    tileGenerated.transform.SetParent(this.transform);
                }
                else if (x<width-1)
                {
                    xPos = x * xOffset;
                    xPos += xOffset / 2f;
                    yPos = y * yOffset;
                    pos.x = xPos;
                    pos.y = yPos;
                    tileGenerated = (GameObject)Instantiate(Tile, pos, Quaternion.identity);
                    tileGenerated.name = "Hex_" + x + "_" + y;
                    tileGenerated.transform.SetParent(this.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
