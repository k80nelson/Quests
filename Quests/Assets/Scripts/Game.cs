using System;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public Game gameState { get { return GameObject.FindObjectOfType<Game>(); } }
}

public class Game : MonoBehaviour
{
    private int numPlayers;
    public int NumPlayers { get { return numPlayers; } }

    public GameObject CardFact;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CardFactory cc = CardFact.GetComponent<CardFactory>();
            QuestOTRT.AdventureCard ally = new QuestOTRT.Ally("Sir Galahad", 0, 0, 0, 0, "1");
            cc.create(ally);
            cc.create(new QuestOTRT.Amour("Amour", 0, 1));

        }
    }
    

}
