using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : CNode
{
    public override void Execute()
    {
        ownerBT.animator.SetTrigger("Idle");
        result = state.success;
    }
}
