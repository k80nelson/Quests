using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    #region Singleton
    public static GameController instance;
    #endregion

    public GameView view;

    public Transform activeArea;
    public int numPlayers = 0;
    public List<PlayerController> players;
    public CardDictionary cardDict;

    void Start()
    {
        Debug.Log("GameController Initialized");
        instance = this;
        this.activeArea = this.transform;
        players = new List<PlayerController>();
    }

    public void makePlayer(PlayerController player)
    {
        if (!isServer) return;
        numPlayers += 1;
        player.gameObject.name = "Player " + numPlayers;
        player.model.index = numPlayers - 1;
        players.Add(player);
        view.makeStat();
        player.onCardsChangedCallback += view.pollStats;
    }
}
