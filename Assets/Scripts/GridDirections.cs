using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDirections
{
   // bool even;
    int maxNoHexes=22;
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
