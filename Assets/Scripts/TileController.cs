using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour, IInputSystem
{
    public UnityEvent SpawnTile;
    IGrid iGrid;
    float startTime;
    float distance;
    Camera MianCam;
    [SerializeField] Vector3 initialPos;
    int noOfTiles;
    List<Tile> tilesList = new List<Tile>();
    List<HexData> tempHex2 = new List<HexData>();
    [SerializeField] GameObject TileParentObj;
    public void Start()
    {
        initialPos = new Vector3(2, -4, 0);
        MianCam = Camera.main;
    }
    public void InitializatingGrid(IGrid grid)
    {
        iGrid = grid;
    }
    public void InitializingTiles()
    {
        string tempstr;
        tempHex2.Clear();
        tilesList.Clear();
        noOfTiles = TileParentObj.transform.childCount;
        for (int i = 0; i < noOfTiles; i++)
        {
            Tile temp = new Tile();
            temp.TileObj = TileParentObj.transform.GetChild(i).gameObject;
            temp.State = false;
            tempstr = temp.TileObj.name.ToString();
            temp.Tier = int.Parse(tempstr[0].ToString());
            tilesList.Add(temp);
        }
    }
    public void TapRotate(Touch touch)
    {
        if (noOfTiles > 0 && tilesList[0].State==false)
        {
            Vector3 pos = touch.position;
            pos = MianCam.ScreenToWorldPoint(pos);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, MianCam.transform.forward, Mathf.Infinity);
            if (hit.collider)
            {
                if (hit.collider.tag == "New Tile")
                {
                    TileParentObj.transform.Rotate(0, 0, 60);
                    for (int i=0;i<noOfTiles;i++)
                    {
                        tilesList[i].TileObj.transform.Rotate(0, 0, -60);
                       
                    }
 
                }
            }
        }
    }
    public bool DetectRay(Touch touch)
    {
        

        Vector3 pos = touch.position;
        pos = MianCam.ScreenToWorldPoint(pos);
        pos.z = 0;
        Vector3 startPos = this.transform.position;
        distance = Vector3.Distance(startPos, pos);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(pos, MianCam.transform.forward, Mathf.Infinity);
        if (hit.collider)
        { 
            if (hit.collider.tag == "New Tile")
            { 
                return true;
            }
        }
        return false;
    }
    public void MovingTile(Touch touch)
    {
        float offset = 1;
        Vector3 pos = touch.position;
        pos = MianCam.ScreenToWorldPoint(pos);
        pos.z = 0;
        pos.y = pos.y +offset;
        Vector3 startPos = TileParentObj.transform.position;//
        distance = Vector3.Distance(startPos, pos);
        TileParentObj.transform.position = Vector3.Lerp(startPos, pos, Time.deltaTime * 2 + distance);
    }
    public void Highlighttiles(Touch touch)
    {
        //bool highlighted = false;
       List<HexData> tempHex = new List<HexData>();
    //   List<HexData> tempHex2 = new List<HexData>();
        bool highlight = true;
        Vector3 deltaPos = Vector3.zero;
        for (int i = 0; i < noOfTiles; i++)
        {
            tempHex.Add(iGrid.GetNearestPositionFromPoint(tilesList[i].TileObj.transform.position + deltaPos));
            if (tempHex[i] == null)
            {
                highlight = false;
                i = noOfTiles;
            }
            else if (i >= 1)
            {
                deltaPos = tempHex[i].Hex.transform.position - tempHex[i - 1].Hex.transform.position;
            }
        }
        if (highlight)
        {
            tempHex2.Clear();
            for (int i = 0; i < noOfTiles; i++)
            {
                tempHex[i].Hex.GetComponent<SpriteRenderer>().color = Color.gray;
                tempHex2.Add(tempHex[i]);
            }
       
        }
        if (tempHex2.Count != 0 && tempHex.Count != 0)
            {
                if(tempHex2[0].Id!=tempHex[0].Id)
                {
                    for (int i = 0; i < tempHex2.Count; i++)
                    {
                        tempHex2[i].Hex.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                tempHex2.Clear();
                }
            }
        //iGrid.ResetColor(tempTiles);
    }
    public void ReturnToPosition(Touch touch)
    {
        if (!tilesList[0].State)
        { 
            Vector3 pos = touch.position;
            pos = MianCam.ScreenToWorldPoint(pos);
            pos.z = 0;
            distance = Vector3.Distance(pos, initialPos);
            TileParentObj.transform.position = Vector3.Lerp(pos, initialPos, Time.deltaTime * 2 + distance); //
        }

    }
    public void SnapOnGrid(Touch touch)
    {
        List<HexData> parentHex = new List<HexData>();
        HexData temp;
        bool snap = true;
        Vector3 touchPos = touch.position;
        touchPos = MianCam.ScreenToWorldPoint(touchPos);
        touchPos.z = 0;
        Vector3 deltaPos = Vector3.zero;
        for (int i = 0; i < noOfTiles; i++)
        { 
            temp=iGrid.GetNearestPositionFromPoint(tilesList[i].TileObj.transform.position + deltaPos);
            if (temp != null)
            {
                parentHex.Add(temp);
            }
            else if(temp==null)
            {
                snap = false;
                i = noOfTiles;
            }
            else if (i >= 1)
            {
                deltaPos = parentHex[i].Hex.transform.position - parentHex[i - 1].Hex.transform.position;
            }
        }
        if (snap)
        {
            for (int i = 0; i < noOfTiles; i++)
            {
                tilesList[i].TileObj.transform.position = parentHex[i].Hex.transform.position;
                tilesList[i].TileObj.transform.SetParent(parentHex[i].Hex.transform);
                tilesList[i].TileObj.tag = "Untagged";
                tilesList[i].TileObj.GetComponent<SpriteRenderer>().sortingOrder = 1;
                TileParentObj.transform.position = initialPos;
                tilesList[i].State = true;
                parentHex[i].Occupied = true;
                parentHex[i].HexTile = tilesList[i];
                iGrid.searching(parentHex[i]);
            }
            SpawnTile.Invoke();
        }
        else
        {
            ReturnToPosition(touch);
        }
    }
    public void skip()
    {
        TileParentObj.transform.DetachChildren();
        for(int i=0;i<noOfTiles;i++)
        {
            Destroy(tilesList[i].TileObj.gameObject);
        }
        //tiles.Clear();
        SpawnTile.Invoke(); 
    }  
}
