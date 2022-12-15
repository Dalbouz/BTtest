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

    public override Status Process()
    {
        return children[currentChild].Process();//ovime pokrecemo process od current child
    }

    struct NodeLevel //koristit cemo struct kako bi mogli odrediti level svakog node-a, npr. root node je lvl 0, sequence node lvl 2, leaf node lvl 3 itd
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
        Stack<NodeLevel> nodeStack = new Stack<NodeLevel>();//radio kao array, Stack radio kao LIFO 
        Node currentNode = this; //prvi node je ustvari nas Behaviour Tree
        nodeStack.Push(new NodeLevel {level = 0, node = currentNode });//dodamo taj currentNode u naš stack zajedno sa njegovim levelom, radimo to preko stuct

        while (nodeStack.Count != 0)
        {
            NodeLevel nextNode = nodeStack.Pop(); //izvužemo van Node koji je sljedeci na stacku
            treePrintOut += new string('-',nextNode.level/* ovisno koji level ovdje bude toliko puta ce se ponoviti ovaj minus*/) + nextNode.node.name + "\n";

            /*Ulazimo dublje u listu nodova, i svaki sljedeci node level ce se povecati za 1*/
            for(int i = nextNode.node.children.Count-1; i >= 0; i--)//taj node koji smo izvukli loopamo kroz njegovu listu nodova ali unatrag, znaci pocnemo od onog koji je zadnji ušao u listu i krecemo se prema nultom indexu
            {
                nodeStack.Push(new NodeLevel { level = nextNode.level + 1, node = nextNode.node.children[i] });//sad taj node koji smo izvukli dodamo u nodeStack i onda ce se on sljedeci upisati 
            }
        }
        Debug.Log(treePrintOut);
    }
}
