using UnityEngine;
using System.Collections.Generic;

public class MySequence : MyNode
{
    private List<MyNode> _children;

    public MySequence(List<MyNode> children)
    {
        this._children = children;
    }
    public override MyNodeStatus Evaluate()
    {
        foreach (MyNode node in _children)
        {
            var status = node.Evaluate();
            if (status == MyNodeStatus.Failure)
                return MyNodeStatus.Failure;

            if (status == MyNodeStatus.Running)
                return MyNodeStatus.Running;
        }
        return MyNodeStatus.Success;
    }
}