using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node //koristeći se ovom klasom, kreirat cemo naše Nodove koji cemo pretvoriti u akcije
{
    public enum Status { 
        SUCCESS, RUNNING, FAILURE
    };
    public Status status;

    public List<Node> children = new List<Node>();
    public int currentChild = 0; //na samom pocetku pocet ce od prvog child objeta s ljeve strane i kretat ce se prema desno 
    public string name;

    public Node() { }
    public Node(string n) //svaki Node koji napravimo u drugoj skripti dodat cemo joj atribut string odnosno naziv naše akcije 
    {
        name = n;
    }

    public void AddChild(Node n)
    {
        children.Add(n); //prvi koji dodamo biti ce na vrhu samog drveta, sto znaci da ih zelimo dodavati u redosljedu u kojem zelimo da budu izvršeni
    }
}
