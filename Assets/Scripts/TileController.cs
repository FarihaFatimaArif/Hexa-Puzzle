using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour, IInputSystem
{
    //Touch touch;
    IGrid iGrid;
    [SerializeField] float Speed = 1;
    //static Vector3 TilestartPos;
    //Vector3 pos;
    float startTime;
    float distance;
    Camera MianCam; 
   // [SerializeField] GameObject TileObj;
    Tile tileRef;
    public void Start()
    {
        //tileRef.Position = new Vector3();
        MianCam = Camera.main;
        Debug.Log(MianCam);
        tileRef = this.GetComponent<Tile>(); //
        tileRef.State = false;
        tileRef.Position = this.transform.position; //
    }
    public void InitializeIGrid(IGrid grid)
    {
        iGrid = grid;
    }
    public void TapRotate(Touch touch)
    {
        Vector3 pos = touch.position;
        pos = MianCam.ScreenToWorldPoint(pos);
        //Vector2 ray = MianCam.ScreenPointToRay(pos);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(pos, MianCam.transform.forward, Mathf.Infinity);
        //Debug.LogError(hit.collider);
        if (hit.collider)
        {
            Debug.Log("rotate 1");
            if (hit.collider.tag == "New Tile")
            {
                this.transform.Rotate(0, 0, 90); //
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

        // float t = Mathf.MoveTowards(startPos, pos, Speed * Time.deltaTime);

        hit = Physics2D.Raycast(pos, MianCam.transform.forward, Mathf.Infinity);
        //Debug.LogError(hit.collider);
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
        Vector3 startPos = this.transform.position;
        distance = Vector3.Distance(startPos, pos);
        this.transform.position = Vector3.Lerp(startPos, pos, Time.deltaTime * 2 + distance);
    }
    public void ReturnToPosition(Touch touch)
    {
        if (!tileRef.State)
        { 
            Vector3 pos = touch.position;
            pos = MianCam.ScreenToWorldPoint(pos);
            pos.z = 0;
            distance = Vector3.Distance(pos, tileRef.Position);
            this.transform.position = Vector3.Lerp(pos, tileRef.Position, Time.deltaTime * 2 + distance); //
        }

    }

    public void SnapOnGrid(Touch touch)
    { 

        Vector3 pos = touch.position;
        pos = MianCam.ScreenToWorldPoint(pos);
        pos.z = 0;
        Vector3? newpos= (Vector3?)iGrid.GetNearestPositionFromPoint(this.transform.position);
        if (newpos != null)
        {
            this.transform.position = (Vector3)newpos; //
            tileRef.State = true;
        }
        else
        {
            Debug.Log("immm");
            Debug.Log(tileRef.State);
            tileRef.State = false;
            ReturnToPosition(touch);
        }
    }
    }
