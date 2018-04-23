using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CNode
{
    public override void Execute()
    {
        for(int i = 0; i < children.Count; i++)
        {
            children[i].Execute();
            if (children[i].result==state.success)
            {
                result = state.success;
                return;
            }
            if (children[i].result == state.running)
            {
                result = state.running;
                return;
            }            
        }
        result = state.failure;
    }
}
