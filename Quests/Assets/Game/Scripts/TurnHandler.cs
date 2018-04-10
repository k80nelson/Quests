using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class TurnHandler : NetworkBehaviour {

    #region Singleton
    public static TurnHandler instance;
    #endregion

    [SyncVar(hook = "OnPlayerChg")]
    public int currPlayer = -1;
    [SyncVar]
    public int totalPlayers = 0;

    private void Awake()
    {
        instance = this;
    }

    void OnPlayerChg(int newVal)
    {
        currPlayer = newVal;
        if (NetPlayerController.LocalPlayer.index == currPlayer)
        {
            NetPlayerController.LocalPlayer.setTurn();
        }
        else
        {
            NetPlayerController.LocalPlayer.unsetTurn();
        }
    }

    [Server]
    public void SetNextPlayer()
    {
        currPlayer = (currPlayer + 1) % totalPlayers;
    }
    
    [Server]
    public void Init()
    {
        totalPlayers = GameManager.instance.numPlayers;
        SetNextPlayer();
    }
}
