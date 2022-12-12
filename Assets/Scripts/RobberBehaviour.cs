using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;

    private void Start()
    {
        tree = new BehaviourTree();
        Node steal = new Node("Steal Something"); //kreiramo nove Nodove za svaku akciju
        Node GoToDiamond = new Node("Go To Diamond");
        Node GoToVan = new Node("Go To Van");

        Node RunAway = new Node("Run Away");
        Node FindExit = new Node("Find Exit");
        Node GoToExit = new Node("Go To Exit");

        //kreiramo behaviour tree
        steal.AddChild(GoToDiamond);//krecemo od zadnje akcije s ljeve strane drveta i krecemo se u desno po istoj ravnini
        steal.AddChild(GoToVan);
        tree.AddChild(steal);//nakraju u sami tree dodajemo Steal Node
        tree.PrintTree();
    }
}
