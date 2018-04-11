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

    private void Start()
    {
        // initializes all players
        for (int i=0; i<players.Count; i++)
        {
            players[i].Init();
            players[i].index = i;
        }
    }

    public Transform getActiveArea()
    {
        // called in Draggable.cs
        return activeArea;
    }
    
    [Server]  public void addReady()
    {
        // Starts the game when all players are fully initialized
        _numReady += 1;
        Debug.Log(_numReady + " Player(s) ready.");
        if (_numReady >= players.Count)
        {
            numPlayers = players.Count;
            TurnHandler.instance.Init();
        }
    }
}
