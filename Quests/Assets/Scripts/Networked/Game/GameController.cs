using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour {

    #region Singleton
    public static GameController instance;
    #endregion

    public Transform activeArea;
    
    public int numPlayers = 0;

    public List<PlayerController> players;
    
    public void addPlayer(PlayerController player)
    {
        player.model.index = numPlayers;
        numPlayers += 1;
        player.model.registered = true;
        players.Add(player);
    }


    public void Start()
    {
        instance = this;
        this.activeArea = this.transform;
        players = new List<PlayerController>();

    }
    
}
