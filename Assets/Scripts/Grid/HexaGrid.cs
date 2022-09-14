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
    [SerializeField] List<Sprite> TilesSprites;
    int maxHexes = 25;
    float xOffset = 1f;
    float yOffset = 0.86f;
    float xPos;
    float yPos;
    int index=0;
    bool once = false;
    GameObject tileGenerated;
    List<HexData> HexesList = new List<HexData>();

    List<HexData> checkedHexes = new List<HexData>();
    Queue<HexData> InqueueHexes = new Queue<HexData>();
    List<HexData> neighbours = new List<HexData>();

    public Dictionary<Vector2, HexData> Hexes = new Dictionary<Vector2, HexData>();


   //[SerializeField] List<Vector2> hexGridPos = new List<Vector2>();
    // Start is called before the first frame update
    void Start()
    {
        Vector3 tilePosition;
        Hexes.Clear();
        Vector2 tempvec = new Vector2();
        HexesList.Clear();
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                HexData temp = new HexData();
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
                    temp.Hex = tileGenerated;
                    temp.Index = index;
                    Debug.Log("index" + index);
                    Debug.Log("id" + tileGenerated.name);
                    temp.Id = tileGenerated.name;
                    tempvec.x = x;
                    tempvec.y = y;
                    Hexes.Add(tempvec, temp);
                    
                    //hexGridPos.Add(tempvec);
                    HexesList.Add(temp);
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
                    temp.Hex = tileGenerated;
                    temp.Index = index;
                    temp.Id = tileGenerated.name;
                    tempvec.x = x;
                    tempvec.y = y;
                    Hexes.Add(tempvec, temp);
                    HexesList.Add(temp);
                    tempvec.x = x;
                    tempvec.y = y;
                    //hexGridPos.Add(tempvec);
                    Debug.Log("index" + index);
                    Debug.Log("id" + tileGenerated.name);
                }
                else if(x==Width-1)
                {
                    HexesList.Add(temp);
                }
                index++;

            }
        }
    }

    public HexData GetNearestPositionFromPoint(Vector3 position)
    {
        float distance;
        foreach (var pair in Hexes)
        {
             distance = Vector3.Distance(pair.Value.Hex.transform.position, position);
            if (distance <= 0.5f && pair.Value.Hex.transform.childCount==0)
            {
                return pair.Value;
            }
        }

        return null;
    }
    public void ResetColor(List<GameObject> temp)
    {
       /* int i = 0;
        foreach (var pair in tiles)
        {
            if (temp[i]!==pair.)
            {
                pair.Value.GetComponent<SpriteRenderer>().color = Color.white;
                Debug.Log("Yrrr");
            }
            i++;
        } */
    }
    public void searching(HexData hex)
    {
        InqueueHexes.Clear();
        neighbours.Clear();
        checkedHexes.Clear();
        InqueueHexes.Enqueue(hex);
        SearchNeighbours(hex);
        Debug.Log("matched neighbours are");

       foreach(var pair in neighbours)
        {
            Debug.Log(pair.Id);
        }
       if(neighbours.Distinct().Count()>=3)
        {
            Debug.Log("finish");
            Merge();
        }
        Debug.Log("finish");
    }
    public void SearchingNeighbours(HexData hex)
    {
        GridDirections directions = new GridDirections();
        HexData temp;
        if (!checkedHexes.Contains(hex))
        {
            List<Vector2> neighbourPositions = new List<Vector2>();
            //neighbourPositions=directions.NeighbourPositions()
            for (int i=0; i<6;i++)
            {

            }
        }
    }
    public void SearchNeighbours(HexData hex)
    {
        GridDirections directions=new GridDirections();
        HexData temp;
        if (!checkedHexes.Contains(hex))
        {
            if (directions.BottomLeft(hex.Index) < maxHexes && directions.BottomLeft(hex.Index) >= 0 && HexesList[directions.BottomLeft(hex.Index)].Occupied && hex.HexTile.Tier == HexesList[directions.BottomLeft(hex.Index)].HexTile.Tier)
            {
                InqueueHexes.Enqueue(HexesList[directions.BottomLeft(hex.Index)]);
                neighbours.Add(hex);
            }
            if (directions.BottomRight(hex.Index) < maxHexes && directions.BottomRight(hex.Index) >= 0 && HexesList[directions.BottomRight(hex.Index)].Occupied && hex.HexTile.Tier == HexesList[directions.BottomRight(hex.Index)].HexTile.Tier)
            {
                InqueueHexes.Enqueue(HexesList[directions.BottomRight(hex.Index)]);
                neighbours.Add(hex);
            }
            if (directions.TopLeft(hex.Index) < maxHexes && directions.TopLeft(hex.Index) >= 0 && HexesList[directions.TopLeft(hex.Index)].Occupied && hex.HexTile.Tier == HexesList[directions.TopLeft(hex.Index)].HexTile.Tier)
            {
                InqueueHexes.Enqueue(HexesList[directions.TopLeft(hex.Index)]);
                neighbours.Add(hex);
            }
            if (directions.TopRight(hex.Index) < maxHexes && directions.TopRight(hex.Index) >= 0 && HexesList[directions.TopRight(hex.Index)].Occupied && hex.HexTile.Tier == HexesList[directions.TopRight(hex.Index)].HexTile.Tier)
            {
                InqueueHexes.Enqueue(HexesList[directions.TopRight(hex.Index)]);
                neighbours.Add(hex);
            }
            if (directions.Left(hex.Index) < maxHexes && directions.Left(hex.Index) >= 0 && HexesList[directions.Left(hex.Index)].Occupied && hex.HexTile.Tier == HexesList[directions.Left(hex.Index)].HexTile.Tier)
            {
                InqueueHexes.Enqueue(HexesList[directions.Left(hex.Index)]);
                neighbours.Add(hex);
            }
            if (directions.Right(hex.Index) < maxHexes && directions.Right(hex.Index) >= 0 && HexesList[directions.Right(hex.Index)].Occupied && hex.HexTile.Tier == HexesList[directions.Right(hex.Index)].HexTile.Tier)  //check tier here instead of below
            { 
                    InqueueHexes.Enqueue(HexesList[directions.Right(hex.Index)]);
                    neighbours.Add(hex);
            }
            checkedHexes.Add(hex);
        }
        while(InqueueHexes.Count>0)
        {
            temp = InqueueHexes.Dequeue();
             SearchNeighbours(temp);
        }
        return;
    }
    public void Merge()
    {
        bool merge = false;
        foreach (var pair in neighbours.Distinct())
        {
            if (!merge)
            { 
                merge = true;
                Debug.Log("b" + pair.HexTile.Tier);
                pair.HexTile.TileObj.GetComponent<SpriteRenderer>().sprite = TilesSprites[pair.HexTile.Tier];
                pair.HexTile.Tier = pair.HexTile.Tier + 1;
                Debug.Log("a" + pair.HexTile.Tier);
            }
            else
            {
            
                pair.Hex.transform.DetachChildren();
                pair.HexTile.TileObj.SetActive(false);
                pair.HexTile.Tier = -1;
                //Debug.Log("b"+pair.HexTile.Tier);
                // pair.HexTile.Tier = pair.HexTile.Tier+1;
                //pair.HexTile.TileObj.GetComponent<SpriteRenderer>().sprite = TilesSprites[pair.HexTile.Tier];
                // Debug.Log("a"+pair.HexTile.Tier);

            }
        }
    }
}
