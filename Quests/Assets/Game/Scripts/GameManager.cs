using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Lobby;

public class GameManager : NetworkBehaviour {

    #region Singleton
    static public GameManager instance = null;  // Singleton
    #endregion

    static public List<NetPlayerController> players = new List<NetPlayerController>();  // STATIC -> list of all players
    
    public Transform statsUIZone;  // To instantiate player stats
    public Transform activeArea;   // For Draggable.cs -> the current game canvas
    public CardDictionary dict;    // Translates a card index into a card object

    int _numReady;                 // Number of players fully instantiated with 12 cards drawn
    public int numPlayers;         // Num players in the game

    private void Awake()
    {
        instance = this;
    }

    // initializes all players
    private void Start()
    {
        for (int i=0; i<players.Count; i++)
        {
            players[i].Init();
            players[i].index = i;
        }
    }

    // called in Draggable.cs
    public Transform getActiveArea()
    {
        return activeArea;
    }


    // Starts the game when all players are fully initialized
    [Server]
    public void addReady()
    {
        _numReady += 1;
        Debug.Log(_numReady + " Player(s) ready.");
        if (_numReady >= players.Count)
        {
            numPlayers = players.Count;
            TurnHandler.instance.Init();
        }
    }
}
