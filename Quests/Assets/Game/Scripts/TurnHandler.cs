using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class TurnHandler : NetworkBehaviour {

    #region Singleton
    public static TurnHandler instance;
    #endregion

    #region Message

    const short EndTurnMsg = MsgType.Highest + 1;

    NetworkClient client;

    public void SendEndTurnMsg()
    {
        EmptyMessage msg = new EmptyMessage();
        client.Send(EndTurnMsg, msg);
    }

    [Server]
    public void OnServerRcvEndTurn(NetworkMessage msg)
    {
        Debug.Log("END OF TURN");
        setNextPlayer();
    }

    #endregion
    
    [SyncVar(hook = "OnCurrPlayerChg")] public int currPlayer = -1;
    [SyncVar] public int totalPlayers = 0;
    [SyncVar(hook = "OnActiveChg")] public int numActive;
    public SyncListInt activePlayers = new SyncListInt();

    [SerializeField] Button storyBtn;
    [SerializeField] Button endTurnBtn;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Lobby.LobbyManager mgr = GameObject.FindObjectOfType<Lobby.LobbyManager>();
        client = mgr.client;
        NetworkServer.RegisterHandler(EndTurnMsg, OnServerRcvEndTurn);
    }

    void OnCurrPlayerChg(int newVal)
    {
        currPlayer = newVal;
        if (NetPlayerController.LocalPlayer.index == currPlayer)
        {
            NetPlayerController.LocalPlayer.setStartTurn();
        }
        else
        {
            NetPlayerController.LocalPlayer.unsetTurn();
        }
    }
    
    void OnActiveChg(int num)
    {
        numActive = num;
        if (!isServer) return;
        foreach(NetPlayerController player in GameManager.players)
        {
            if (activePlayers.Contains(player.index))
            {
                player.setActive();
            }
            else
            {
                player.unSetActive();
            }
        }
    }
    
    [Client]
    public void showTurnUI()
    {
        storyBtn.interactable = true;
        endTurnBtn.gameObject.SetActive(true);
    }

    [Client]
    public void unShowTurnUI()
    {
        storyBtn.interactable = false;
        endTurnBtn.gameObject.SetActive(false);
    }

    // CALLED TO BEGIN A TURN COMPLETELY
    [Server]
    public void setNextPlayer()
    {
        clearActive();                  // Calls UnSetActive() on all playercontrollers
        addActivePlayer(nextPlayer());  // Calls setActive() on NextPlayer
        SetCurrPlayer(nextPlayer());    // Calls setStartTurn() on NextPlayer
    }

    [Server]
    public void addActivePlayer(int player)
    {
        activePlayers.Add(player);
        numActive += 1;
    }

    [Server]
    public void setActivePlayers(List<int> players)
    {
        clearActive();
        foreach(int player in players)
        {
            activePlayers.Add(player);
        }
        numActive = players.Count;
    }

    [Server]
    public void removeActivePlayer(int player)
    {
        activePlayers.Remove(player);
        numActive -= 1;
    }

    [Server]
    public void clearActive()
    {
        activePlayers.Clear();
        numActive = 0;
    }

    [Server]
    public void SetCurrPlayer(int player)
    {
        currPlayer = player;
    }

    [Server]
    public int nextPlayer()
    {
        return (currPlayer + 1) % totalPlayers;
    }
    
    [Server]
    public void Init()
    {
        totalPlayers = GameManager.instance.numPlayers;
        setNextPlayer();
    }
}
