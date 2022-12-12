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
        public Node node;
    }


    /* PRINT BEHAVIOUR TREE U KONZOLU KORISTECI SE LISTOM I FOR PETLJOM
    public void PrintTree()
    {
        string TreePrintout = "";
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
    */

    public void PrintTree()
    {
        string treePrintOut = "";
    }
}
