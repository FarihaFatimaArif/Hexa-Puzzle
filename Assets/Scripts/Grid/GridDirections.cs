using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDirections
{
    int maxNoHexes=22;
    List<Vector2> NeighbourPositions(Vector2 currentPos)
    {
        List<Vector2> neighbourPositions = new List<Vector2>();
        neighbourPositions.Add(BottomLeftNeighbour(currentPos));
        neighbourPositions.Add(LeftNeighbour(currentPos));
        neighbourPositions.Add(TopLeftNeighbour(currentPos));
        neighbourPositions.Add(BottomRightNeighbour(currentPos));
        neighbourPositions.Add(RightNeighbour(currentPos));
        neighbourPositions.Add(TopLeftNeighbour(currentPos));
        return neighbourPositions;
    }
    Vector2 BottomRightNeighbour(Vector2 currentPos)
    {
        currentPos.x = currentPos.x + 1;
        currentPos.y = currentPos.y - 1;
        return currentPos;
    }
    Vector2 TopRightNeighbour(Vector2 currentPos)
    {
        currentPos.y = currentPos.y + 1;
        currentPos.x = currentPos.x + 1;
        return currentPos;
    }
    Vector2 BottomLeftNeighbour(Vector2 currentPos)
    {
        currentPos.y = currentPos.y - 1;
        return currentPos;
    }
    Vector2 TopLeftNeighbour(Vector2 currentPos)
    {
        currentPos.y = currentPos.y + 1;
        return currentPos;
    }
    Vector2 LeftNeighbour(Vector2 currentPos)
    {
        currentPos.x = currentPos.x - 1;
        return currentPos;
    }
    Vector2 RightNeighbour(Vector2 currentPos)
    {
        currentPos.x = currentPos.x + 1;
        return currentPos;
    }


    bool checkrow(int i)
    {
        int temp = i % 5;
        if(temp%2==0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int BottomRight(int i)
    {
        if (checkrow(i))
        {
          
            return i - 1;
        }
       
        return i+4;
    }
    public int BottomLeft(int i)
    {
        if (checkrow(i))
        { 
            return i - 6;
        }
       
        return i-1;
    }
    public int TopRight(int i)
    {
        if (checkrow(i))
        {
            
            return i + 1;
        }
        
        return i+6;
    }
    public int TopLeft(int i)
    {
        if (checkrow(i))
        {
            return i - 4;
        }
        return i+1;
    }
    public int Right(int i)
    {
        return i + 5;
    }
    public int Left(int i)
    {
        return i - 5;
    }
}
