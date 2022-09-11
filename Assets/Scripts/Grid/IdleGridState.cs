using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleGridState : GridState
{
    IdleGridState(IGridState state) : base(state)
    {
    }
    public override void Snapped()
    {
        Listner.ChangeState(new SearchGridState(Listner));
    }
}
