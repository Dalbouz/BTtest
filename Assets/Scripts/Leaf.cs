using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Tick();//kao frame za na� BT
    public Tick ProcessMethod;

    public Leaf() { }

    public Leaf(string n, Tick pm)
    {
        name = n;
        ProcessMethod = pm;
    }

    public override Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();
        return Status.FAILURE;
    }
}
