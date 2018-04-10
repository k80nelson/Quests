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

    #region Message            // To communicate w the server

    const short EndTurnMsg = MsgType.Highest + 1;

    NetworkClient client;

    #endregion
    
    [SyncVar(hook = "OnCurrPlayerChg")] public int currPlayer = -1;  // The player drawing the current story card
    [SyncVar] public int totalPlayers = 0;                 // total num players
    [SyncVar(hook = "OnActiveChg")] public int numActive;  // the number of currently 'active' players
    public SyncListInt activePlayers = new SyncListInt();  // list of active players

    [SerializeField] Button storyBtn;      // the story deck btn
    [SerializeField] Button endTurnBtn;    // the end turn btn
    
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

    // Called every time currPlayer changes
    void OnCurrPlayerChg(int newVal)
    {
        currPlayer = newVal;
        if (NetPlayerController.LocalPlayer.index == currPlayer)
        {
            // local player is the current player
            NetPlayerController.LocalPlayer.setStartTurn();
        }
        else
        {
            // local player is not the current player
            NetPlayerController.LocalPlayer.unsetTurn();
        }
    }
    
    // called every time activeplayers is changed
    void OnActiveChg(int num)
    {
        numActive = num;
        if (!isServer) return;
        foreach(NetPlayerController player in GameManager.players)
        {
            if (activePlayers.Contains(player.index))
            {
                // activePlayers contains this player, set them active
                player.setActive();
            }
            else
            {
                // deactivate them
                player.unSetActive();
            }
        }
    }

    // called when a player presses end turn from the client to the server
    public void SendEndTurnMsg()
    {
        EmptyMessage msg = new EmptyMessage();
        client.Send(EndTurnMsg, msg);   // sends the end turn msg to the server
    }

    // called when the server recieves an end turn msg
    [Server]
    public void OnServerRcvEndTurn(NetworkMessage msg)
    {
        setNextPlayer();
    }

    // shows local turn ui (makes story btn interactable n activates end turn btn)
    [Client]
    public void showTurnUI()
    {
        storyBtn.interactable = true;
        endTurnBtn.gameObject.SetActive(true);
    }


    // hides local ui (story btn is no longer interactable, end turn btn disappears)
    [Client]
    public void unShowTurnUI()
    {
        storyBtn.interactable = false;
        endTurnBtn.gameObject.SetActive(false);
    }

    // CALLED TO CHANGE A TURN COMPLETELY -> expects the next move to be currplayer drawing an adventure card
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

    // shouldn't be called directly
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
