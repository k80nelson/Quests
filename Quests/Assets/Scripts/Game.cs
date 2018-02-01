using System;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public Game gameState { get { return GameObject.FindObjectOfType<Game>(); } }
}

public class Game : MonoBehaviour {

    public int numPlayers;
    public string[] currCards;

    //winlse is for finally of game, playerleft is for when AI or conclude game needs to be chosen
    private enum state{menu, game, pause, playerLeft, winlose};
    

    //total turns taken so far (for progress)
    private int turns;

    void Start()
    {
        CardCreator.createAlly("King Arthur", 1, 1, 10, 2, "Hello");
        QuestOTRT.Ally all = new QuestOTRT.Ally("Sir Galahad", 1, 1, 10, 2, "Hello");
        CardCreator.createAlly(all);
        
    }
        
    void Update()
    {
            
    }
}
