using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MySelector : MyNode
{
    private List<MyNode> _children;

    public MySelector(List<MyNode> children)
    {
        this._children = children;
    }
    public override MyNodeStatus Evaluate()
    {
        foreach (var node in _children)
        {
            var status = node.Evaluate();
            if (status == MyNodeStatus.Success)
                return MyNodeStatus.Success;
            
            if (status == MyNodeStatus.Running)
                return MyNodeStatus.Running;
        }

        return MyNodeStatus.Failure;
    }
}
