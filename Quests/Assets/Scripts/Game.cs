using System;
using UnityEngine;

public class GameElement : MonoBehaviour
{
    public Game gameState { get { return GameObject.FindObjectOfType<Game>(); } }
}

public class Game : MonoBehaviour
{
    public int numPlayers;
    public int numControlled;
    public GameObject[] Players;
    public DeckController Deck;

    void Start()
    {
        Deck = GameObject.FindWithTag("Deck").GetComponent<DeckController>();
        initPlayers();
    }

    void Update()
    {
        
    }

    void initPlayers()
    {
        PlayerController ctrl;
        foreach (GameObject player in Players)
        {
            ctrl = player.GetComponent<PlayerController>();
            ctrl.player.addCards(Deck.DrawAdventureCards(12));
        }
    }
}
