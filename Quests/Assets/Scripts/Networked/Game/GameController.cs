using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    #region Singleton
    public static GameController instance;
    #endregion

    [SerializeField]
    public GameView view;
    Transform activeArea;

    public CardDictionary cardDict;

    int players = 0;
    
    void OnPlayerChange(int currPlayer)
    {
        PromptController.instance.promptAllUsers("Game", "All users here");
    }

    void Start()
    {
        Debug.Log("GameController Initialized");
        instance = this;
        this.activeArea = this.transform;
    }

    public Transform getActiveArea()
    {
        return activeArea;
    }

    public void makePlayer(PlayerController player)
    {
        if (!isServer) return;
        GameModel.instance.addPlayer(player);
        int index = GameModel.instance.NumPlayers - 1;
        player.gameObject.name = "Player " + (index+1);
        player.model.index = index;
        view.makeStat(player);

    }

    public void readyPlayer()
    {
        GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<PlayerController>().readyPlayer();
    }

    [Server]
    public void addReady()
    {
        if (!isServer) return;
        players += 1;
        if (players >= GameModel.totalPlayers) Debug.Log("got all players");
    }
    
    public void playerLoaded()
    {
        view.showOverlay();
    }

}
