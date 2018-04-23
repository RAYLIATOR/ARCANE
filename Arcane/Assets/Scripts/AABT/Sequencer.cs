using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequencer : CNode
{
    public override void Execute()
    {
        for (int i = 0; i < children.Count;i++)
        {
            children[i].Execute();           
            if (children[i].result == state.running)
            {
                result = state.running;
                return;
            }
            if (children[i].result == state.failure)
            {
                result = state.failure;
                return;
            }
        }
        result = state.success;
    }
}
