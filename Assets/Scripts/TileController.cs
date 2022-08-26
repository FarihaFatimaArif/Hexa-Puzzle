using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour, IInputSystem
{
    public UnityEvent SpawnTile;
    IGrid iGrid;
    float startTime;
    float distance;
    Camera MianCam;
    Vector3 initialPos;
    GameObject tileParentObj;
    GameObject tileObj;
    GameObject tileObj2;
    Tile tileRef;
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
        tileParentObj = GameObject.FindGameObjectWithTag("Parent Tile");
        tileObj = tileParentObj.transform.GetChild(0).gameObject;
        if (tileParentObj.transform.childCount > 1)
        {
            tileObj2 = tileParentObj.transform.GetChild(1).gameObject;
        }
        tileRef = tileObj.GetComponent<Tile>(); //
        tileRef.State = false;
        tileRef.Position = tileParentObj.transform.position;
    }
    public void TapRotate(Touch touch)
    {
        if (tileParentObj.transform.childCount > 0 && tileRef.State==false)
        {
            Vector3 pos = touch.position;
            pos = MianCam.ScreenToWorldPoint(pos);
            RaycastHit2D hit;
            hit = Physics2D.Raycast(pos, MianCam.transform.forward, Mathf.Infinity);
            if (hit.collider)
            {
                if (hit.collider.tag == "New Tile")
                {
                    tileParentObj.transform.Rotate(0, 0, 60); //
                    tileParentObj.transform.GetChild(0).transform.Rotate(0, 0, -60);
                    tileParentObj.transform.GetChild(1).transform.Rotate(0, 0, -60);
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
        Vector3 startPos = tileParentObj.transform.position;//
        distance = Vector3.Distance(startPos, pos);
        tileParentObj.transform.position = Vector3.Lerp(startPos, pos, Time.deltaTime * 2 + distance);//
        highlighttiles();
    }
    void highlighttiles()
    {
        
    }    
    public void ReturnToPosition(Touch touch)
    {
        if (!tileRef.State)
        { 
            Vector3 pos = touch.position;
            pos = MianCam.ScreenToWorldPoint(pos);
            pos.z = 0;
            distance = Vector3.Distance(pos, tileRef.Position);
            tileParentObj.transform.position = Vector3.Lerp(pos, tileRef.Position, Time.deltaTime * 2 + distance); //
        }

    }

    public void SnapOnGrid(Touch touch)
    { 
        Vector3 pos = touch.position;
        Vector3 deltaPos=Vector3.zero;
        bool dual = false;
       if(tileParentObj.transform.childCount>1)
        {
            dual = true;
            tileObj2 = tileParentObj.transform.GetChild(1).gameObject;
            deltaPos = tileObj2.transform.position - tileObj.transform.position;
           /* Debug.Log(deltaPos);
            Debug.Log("deltaPos");
            Debug.Log(tileObj.transform.position);
            Debug.Log("tileObj.transform.position");
            Debug.Log(tileObj2.transform.position);
            Debug.Log("tileObj.transform.position"); */
            //Debug.Log(deltaPos);

        }
        pos = MianCam.ScreenToWorldPoint(pos);
        pos.z = 0;
        Vector3? newpos = (Vector3?)iGrid.GetNearestPositionFromPoint(tileObj.transform.position, deltaPos);
        if (newpos != null)
        {
            GameObject NewParent = iGrid.FindTile((Vector3)newpos);
            if (NewParent.transform.childCount == 0 && dual==false)
            {
                tileObj.transform.position = (Vector3)newpos;
                tileRef.State = true;
                /* if (tileParentObj.transform.childCount > 1)
                {
                    tileObj2.transform.position = (Vector3)newpos + deltaPos;
                    GameObject NewParent2 = iGrid.FindTile((Vector3)newpos + deltaPos);
                    tileObj2.transform.SetParent(NewParent2.transform);
                    tileObj2.tag = "Untagged";
                } */
                tileObj.transform.SetParent(NewParent.transform);
                tileObj.tag = "Untagged";
                tileParentObj.transform.position = initialPos;
                SpawnTile.Invoke();
            }
            else if(dual==true)
            {
                GameObject NewParent2 = iGrid.FindTile((Vector3)newpos + deltaPos);
                if (NewParent.transform.childCount == 0 && NewParent2.transform.childCount == 0)
                {
                    tileObj.transform.position = (Vector3)newpos;
                    tileRef.State = true;
                    tileObj2.transform.position = (Vector3)newpos + deltaPos;
                    tileObj2.transform.SetParent(NewParent2.transform);
                    tileObj2.tag = "Untagged";
                    tileObj.transform.SetParent(NewParent.transform);
                    tileObj.tag = "Untagged";
                    tileParentObj.transform.position = initialPos;
                    SpawnTile.Invoke();
                }
                else
                {
                    tileRef.State = false;
                    ReturnToPosition(touch);
                }
            }
            else
            {
                tileRef.State = false;
                ReturnToPosition(touch);
            }
        }
        else
        {
            tileRef.State = false;
            ReturnToPosition(touch);
        }
    }
    }
