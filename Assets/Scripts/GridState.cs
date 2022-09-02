using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GridState
{
    protected IGridState Listner;
    public GridState(IGridState state)
    {
        Listner = state;
    }
    public virtual void Snapped()
    {

    }
    public virtual void Excution()
    {

    }
    public virtual void End()
    {

    }

}