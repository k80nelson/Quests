using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Lobby;

public class GameManager : NetworkBehaviour {

	static public List<NetPlayerController> players = new List<NetPlayerController>();
    static public GameManager instance = null;
    
    public Transform statsUIZone;
    public Transform activeArea;
    public CardDictionary dict;

    int _numReady;
    public int numPlayers;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (isServer)
        {

        }
        for (int i=0; i<players.Count; i++)
        {
            players[i].Init();
            players[i].index = i;
        }
    }

    public Transform getActiveArea()
    {
        return activeArea;
    }

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
