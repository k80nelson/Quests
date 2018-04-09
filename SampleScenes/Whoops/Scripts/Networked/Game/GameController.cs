using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    #region Singleton
    public static GameController instance;
    #endregion

    [SerializeField] public GameView view;
    Transform activeArea;

    public CardDictionary cardDict;

    List<int> clientConnections = new List<int>();

    void Start()
    {
        instance = this;
        this.activeArea = this.transform;
    }

    public Transform getActiveArea()
    {
        return activeArea;
    }

    public void makePlayer(GPlayerController player, int connectionid)
    {
        if (!isServer) return;
        GameModel.instance.addPlayer(player);
        int index = GameModel.instance.NumPlayers - 1;
        player.gameObject.name = "Player " + (index+1);
        player.model.index = index;
        view.makeStat(player);
        PromptHandler.instance.sendPromptToUsers("New User", "A new user has joined!", clientConnections);
        clientConnections.Add(connectionid);
    }

}
