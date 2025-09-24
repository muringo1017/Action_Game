using System;
using UnityEngine;

public class MyLeaf : MyNode
{
    private Func<MyNodeStatus> _action;

    public MyLeaf(Func<MyNodeStatus> action)
    {
        this._action = action;
    }
    
    public override MyNodeStatus Evaluate()
    {
        return _action();
    }
}
