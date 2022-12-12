using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree : Node
{
    public  BehaviourTree()
    {
       name = "Tree";
    }

    public  BehaviourTree (string m)
    {
        name = m;
    }


    struct NodeLevel
    {
        public int level;
    }

    public void PrintTree()
    {
        string TreePrintout = "";
        NodeLevel NextNode = new NodeLevel { level = 0 };
        for (int y = 0; y < children.Count; y++)
        {
            TreePrintout += "-" + children[y].name + "\n";
            for (int i = 0; i < children[y].children.Count; i++)
            {
                TreePrintout += "--" + children[y].children[i].name + "\n";
            }
        }
        Debug.Log(TreePrintout);
    }
}
