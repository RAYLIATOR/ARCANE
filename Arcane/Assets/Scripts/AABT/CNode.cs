using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNode
{
    public CNode()
    {
        children = new List<CNode>();
    }
    public EnemyBT ownerBT;
    //List to store children of each node.
    public List<CNode> children; 
    public enum state {success, running, failure};
    public state result;
    public virtual void Execute()
    {

    }/*
    public void Add_Behaviour(CNode newBehaviour)
    {        
        children.Add(newBehaviour);
    }
    public void Add_Selector(CNode newSelector)
    {
        children.Add(newSelector);
    }
    public void Add_Sequencer(CNode newSequencer)
    {
        children.Add(newSequencer);
    }*/

    public void assignOwner(EnemyBT owner)
    {
        ownerBT = owner;
        for(int i = 0; i < children.Count; i++)
        {
            children[i].assignOwner(owner);
        }
    }
}
