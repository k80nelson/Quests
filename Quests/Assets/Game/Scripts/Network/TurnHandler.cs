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

    // ---- ATTRIBUTES ----

    // UI

    [SerializeField] Button storyBtn;      // the story deck btn
    [SerializeField] Button endTurnBtn;    // the end turn btn

    // PLAYERS 

    public GameObject currPlayerObject;                                   // SERVER ONLY current player GameObjecy
    public List<GameObject> activePlayerObjects = new List<GameObject>(); // SERVER ONLY list of active playero GameObjects
    public SyncListInt activePlayers = new SyncListInt();                 // list of active players
    [SyncVar(hook = "OnCurrPlayerChg")] public int currPlayer = -1;       // The player drawing the current story card
    [SyncVar(hook = "OnActiveChg")] public int numActive;                 // the number of currently 'active' players
    [SyncVar] public int totalPlayers = 0;                                // total num players

    // NETWORKING 
    
    const short EndTurnMsg = MsgType.Highest + 1;  // Message code
    NetworkClient client;  // Networking client

    // ---- INITIALIZATION ----

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
    
    [Server] public void Init()
    {
        totalPlayers = GameManager.instance.numPlayers;
        setNextPlayer();
    }

    // ---- SYNCVAR HOOKS ----

    void OnCurrPlayerChg(int newVal)
    {
        // Called every time currPlayer changes
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
    
    void OnActiveChg(int num)
    {
        // called every time activeplayers is changed
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

    // ---- CLIENT PUBLIC LOCAL METHODS ----
    
    [Client] public void showTurnUI()
    {
        // shows local turn ui (makes story btn interactable n activates end turn btn)
        storyBtn.interactable = true;
        endTurnBtn.gameObject.SetActive(true);
    }
    
    [Client] public void unShowTurnUI()
    {
        // hides local ui (story btn is no longer interactable, end turn btn disappears)
        storyBtn.interactable = false;
        endTurnBtn.gameObject.SetActive(false);
    }

    // ---- SERVER METHODS ----

    [Server] public void setNextPlayer()
    {
        // CALLED TO CHANGE A TURN COMPLETELY -> expects the next move to be currplayer drawing an adventure card
        clearActive();                  // Calls UnSetActive() on all playercontrollers
        addActivePlayer(nextPlayer());  // Calls setActive() on NextPlayer
        SetCurrPlayer(nextPlayer());    // Calls setStartTurn() on NextPlayer
    }

    [Server] public void addActivePlayer(int player)
    {
        activePlayers.Add(player);
        numActive += 1;
        activePlayerObjects.Add(GameManager.players[player].gameObject);
    }

    [Server]  public void setActivePlayers(List<int> players)
    {
        clearActive();
        foreach (int player in players)
        {
            activePlayers.Add(player);
            activePlayerObjects.Add(GameManager.players[player].gameObject);
        }
        numActive = players.Count;
    }

    [Server] public void removeActivePlayer(int player)
    {
        activePlayers.Remove(player);
        numActive -= 1;
        activePlayerObjects.Remove(GameManager.players[player].gameObject);
    }

    [Server] public void clearActive()
    {
        activePlayers.Clear();
        numActive = 0;
        activePlayerObjects.Clear();
    }

    [Server] public void SetCurrPlayer(int player)
    {
        // shouldn't be called directly
        currPlayer = player;
        currPlayerObject = GameManager.players[player].gameObject;
    }

    [Server] public int nextPlayer()
    {
        return (currPlayer + 1) % totalPlayers;
    }

    // ---- NETWORKING ----

    public void SendEndTurnMsg()
    {
        // called when a player presses end turn from the client to the server
        EmptyMessage msg = new EmptyMessage();
        client.Send(EndTurnMsg, msg);   // sends the end turn msg to the server
    }

    [Server] public void OnServerRcvEndTurn(NetworkMessage msg)
    {
        // called when the server recieves an end turn msg
        setNextPlayer();
    }


}
