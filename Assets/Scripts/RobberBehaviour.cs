using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobberBehaviour : MonoBehaviour
{
    BehaviourTree tree;
    public GameObject diamond;
    public GameObject van;
    NavMeshAgent agent;
    public enum ActionState { IDLE, WORKING };
    ActionState state = ActionState.IDLE;

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        tree = new BehaviourTree();
        Node steal = new Node("Steal Something"); //kreiramo nove Nodove za svaku akciju
        Leaf goToDiamond = new Leaf("Go To Diamond",GoToDiamond);
        Leaf goToVan = new Leaf("Go To Van",GoToVan);

     
        //kreiramo behaviour tree
        steal.AddChild(goToDiamond);//krecemo od zadnje akcije s ljeve strane drveta i krecemo se u desno po istoj ravnini
        steal.AddChild(goToVan);
        tree.AddChild(steal);//nakraju u sami tree dodajemo Steal Node

        tree.Process();//ovo ce pokrenuti BT od ovoj objekta

        tree.PrintTree();
    }

    public Node.Status GoToDiamond()
    {
        return GoToLocation(diamond.transform.position);
    }
    public Node.Status GoToVan()
    {
        return GoToLocation(van.transform.position);
    }

    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTaret = Vector3.Distance(destination, this.transform.position);
        if(state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if(Vector3.Distance(agent.pathEndPosition,destination)>=2)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTaret < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}
