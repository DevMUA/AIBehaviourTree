using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();
    List<Node> removedNodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }
       public override NodeState Evaluate()
    {
        foreach(var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;
                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;
                case NodeState.FAILURE:
                default:
                    break;
            }
        }
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
/*
    public void RemoveNodeFromList(int index)
    {
        removedNodes.Add(nodes[index]);
        nodes.RemoveAt(index);
    }

    public void AddNodeToList(int index)
    {
        nodes.Insert(index, removedNodes[0]);
        removedNodes.RemoveLast();
    }*/
}
