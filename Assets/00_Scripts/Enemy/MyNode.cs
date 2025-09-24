using UnityEngine;


public enum MyNodeStatus { Success, Failure, Running }

public abstract class MyNode
{
    public abstract MyNodeStatus Evaluate();
}
