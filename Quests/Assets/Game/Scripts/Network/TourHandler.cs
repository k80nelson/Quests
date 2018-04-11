using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class TourHandler : NetworkBehaviour {

    #region Singleton

    public static TourHandler instance;

    #endregion

    #region Network Codes
    const int BeginTourJoinCode = MsgType.Highest + 20;
    const int TourAcceptCode = MsgType.Highest + 21;
    const int TourRejectCode = MsgType.Highest + 22;
    const int initTourCode = MsgType.Highest + 23;
    const int sendCardsCode = MsgType.Highest + 24;
    const int startTieCode = MsgType.Highest + 25;
    const int tourwincode = MsgType.Highest + 26;
    const int tourlosecode = MsgType.Highest + 27;
    #endregion

    public class TourMessage : MessageBase
    {
        public int playerId;
        public int totalBp;
    };

    // ---- ATTRIBUTES ----

    NetworkClient client;

    int currCardId;
    TournamentCard currCard;

    int numJoined = 0;
    int firstAsked;
    int currentIndex;
    GameObject currPlayerObj;
    public SyncListInt tourPlayers = new SyncListInt();


    Dictionary<int, int> playerTotals;
    int numSubmitted = 0;

    bool _isTie = false;
    
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        numJoined = 0;
        Lobby.LobbyManager mgr = GameObject.FindObjectOfType<Lobby.LobbyManager>();
        client = mgr.client;
        playerTotals = new Dictionary<int, int>();
        if (isClient)
        {
            client.RegisterHandler(BeginTourJoinCode, OnRcvJoinTour);
            client.RegisterHandler(initTourCode, OnRcvInitTour);
            client.RegisterHandler(startTieCode, OnRcvTie);
            client.RegisterHandler(tourwincode, OnRcvWin);
            client.RegisterHandler(tourlosecode, OnRcvLose);
        }
        if (isServer)
        {
            NetworkServer.RegisterHandler(BeginTourJoinCode, OnRcvTourStartMsg);
            NetworkServer.RegisterHandler(TourAcceptCode, OnClientAccept);
            NetworkServer.RegisterHandler(TourRejectCode, OnClientRefuse);
            NetworkServer.RegisterHandler(sendCardsCode, OnRcvCards);
        }
    }

    [Client] public void SendServerTourStartMsg(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        client.Send(BeginTourJoinCode, msg);
    }

    [Server] void OnRcvTourStartMsg(NetworkMessage msg)
    {

        numJoined = 0;
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        tourPlayers.Clear();
        _isTie = false;
        currCardId = data.value;
        currCard = GameManager.instance.dict.findCard(currCardId) as TournamentCard;
        if (TurnHandler.instance.currPlayerObject != null)
        {
            firstAsked = TurnHandler.instance.currPlayer;
            currentIndex = firstAsked;
            currPlayerObj = TurnHandler.instance.currPlayerObject;
            SendClientJoinTour(currPlayerObj, data.value);
        }
    }

    [Server] void SendClientJoinTour(GameObject player, int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        NetworkServer.SendToClientOfPlayer(player, BeginTourJoinCode, msg);
    }

    [Client] void OnRcvJoinTour(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        GameSceneManager.instance.showJoinTour(data.value);
    }

    [Client] public void SendServerAcceptTour(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        client.Send(TourAcceptCode, msg);
    }

    [Server] void OnClientAccept(NetworkMessage msg)
    {
        numJoined += 1;
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        tourPlayers.Add(data.value);
        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currPlayerObj }, "Quest", GameManager.players[currentIndex].name + " has accepted the tournament.");
        currentIndex = TurnHandler.instance.playerAfter(currentIndex);
        if (currentIndex == firstAsked)
        {
            startTour();
        }
        else
        {
            currPlayerObj = GameManager.players[currentIndex].gameObject;
            SendClientJoinTour(currPlayerObj, currCardId);
        }
    }

    [Client] public void SendServerRefuseTour(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        client.Send(TourRejectCode, msg);
    }

    [Server] void OnClientRefuse(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currPlayerObj }, "Quest", GameManager.players[currentIndex].name + " has declined the tournament.");
        currentIndex = TurnHandler.instance.playerAfter(currentIndex);
        if (currentIndex == firstAsked)
        {
            startTour();
        }
        else
        {
            currPlayerObj = GameManager.players[currentIndex].gameObject;
            SendClientJoinTour(currPlayerObj, currCardId);
        }
    }

    [Server] void sendInitTour()
    {
        EmptyMessage msg = new EmptyMessage();
        NetworkServer.SendToAll(initTourCode, msg);
    }

    [Client] void OnRcvInitTour(NetworkMessage msg)
    {
        if (tourPlayers.Contains(NetPlayerController.LocalPlayer.index))
        {
            GameSceneManager.instance.showTour(currCardId);
        }
        else
        {
            PromptHandler.instance.localPrompt("Tournamanet", "Tournament is in progress.");
        }
    }



    [Client] public void SendServerPlayedCards(int player, int total)
    {
        TourMessage msg = new TourMessage();
        msg.playerId = player;
        msg.totalBp = total;
        client.Send(sendCardsCode, msg);
    }

    [Server]
    void OnRcvCards(NetworkMessage msg)
    {
        TourMessage data = msg.ReadMessage<TourMessage>();

        playerTotals[data.playerId] = data.totalBp;
        numSubmitted += 1;
        if (numSubmitted >= tourPlayers.Count)
        {
            numSubmitted = 0;
            tourTryEnd();
        }
    }

    [Server] void tourTryEnd()
    {
        List<int> winners = new List<int>();
        int highestBp = 0;

        foreach (int player in tourPlayers)
        {
            Debug.Log("Finding Winners");
            int playerBP = playerTotals[player];
            if (playerBP > highestBp)
            {
                winners.Clear();
                winners.Add(player);
                highestBp = playerBP;
            }
            else if (playerBP == highestBp)
            {
                winners.Add(player);
            }
        }

        /* after finding winners, remove the losers */

        List<int> losers = new List<int>(tourPlayers);
        List<int> models = new List<int>(tourPlayers);
        foreach (int player in models)
        {
            if (winners.Contains(player))
            {
                losers.Remove(player);
                continue;
            }
            else
            {
                tourPlayers.Remove(player);
            }
            
        }
        if (_isTie && tourPlayers.Count > 1)
        {
            foreach(int player in tourPlayers)
            {
                sendWin(GameManager.players[player].gameObject);
            }
            foreach(int player in losers)
            {
                sendFail(GameManager.players[player].gameObject);
            }
            promptWin();
            EndTour();
        }
        else if (tourPlayers.Count > 1)
        {
            _isTie = true;
            foreach(int player in tourPlayers)
            {
                sendClientTie(GameManager.players[player].gameObject);
            }
            foreach(int player in losers){
                sendFail(GameManager.players[player].gameObject);
            }
            promptTie();
        }
        else
        {
            foreach (int player in tourPlayers)
            {
                sendWin(GameManager.players[player].gameObject);
            }
            foreach (int player in losers)
            {
                sendFail(GameManager.players[player].gameObject);
            }
            promptWin();
            EndTour();
        }
    }

    [Server] void promptWin()
    {
        string winners = "Tour Ended: " + GameManager.players[tourPlayers[0]].name;
        for(int i=1; i<tourPlayers.Count; i++)
        {
            winners += ", " + GameManager.players[tourPlayers[i]].name;
        }
        winners += " won the tournament.";
        PromptHandler.instance.SendPromptToAll("Tournament", winners);
    }
    [Server] void promptTie()
    {
        playerTotals.Clear();
        string winners = "Tour tie: " + GameManager.players[tourPlayers[0]].name;
        for (int i = 1; i < tourPlayers.Count; i++)
        {
            winners += ", " + GameManager.players[tourPlayers[i]].name;
        }
        winners += " continuing the tournament.";
        PromptHandler.instance.SendPromptToAll("Tournament", winners);
    }

    [Server] void EndTour()
    {
        Debug.Log("TourEnd");
        foreach (int player in tourPlayers)
        {
            Debug.Log("Adding shields to " + GameManager.players[player].name);
            GameManager.players[player].addShields(currCard.shields + numJoined);
        }
        numJoined = 0;
        destroyTour();
    }

    [Server] void sendClientTie(GameObject client)
    {
        NetworkServer.SendToClientOfPlayer(client, startTieCode, new EmptyMessage());
    }

    [Client] void OnRcvTie(NetworkMessage msg)
    {
        GameSceneManager.instance.startTourTie();
    }
    [Server]
    void sendWin(GameObject client)
    {
        NetworkServer.SendToClientOfPlayer(client, tourwincode, new EmptyMessage());
    }

    [Client]
    void OnRcvWin(NetworkMessage msg)
    {
        GameSceneManager.instance.tourWin();
    }
    [Server]
    void sendFail(GameObject client)
    {
        NetworkServer.SendToClientOfPlayer(client, tourlosecode, new EmptyMessage());
    }

    [Client]
    void OnRcvLose(NetworkMessage msg)
    {
        GameSceneManager.instance.tourFail();
    }

    [Server] void startTour()
    {
        if (tourPlayers.Count == 0)
        {
            destroyTour();
        }
        else
        {
            numSubmitted = 0;
            _isTie = false;
            playerTotals.Clear();
            sendInitTour();
        }
    }

    [Server] void destroyTour()
    {
        currCardId = 0;
        currCard = null;

        numJoined = 0;
        firstAsked = -1;
        currentIndex = -1;
        currPlayerObj = null;
        tourPlayers.Clear();


        playerTotals = new Dictionary<int, int>();
        numSubmitted = 0;

        _isTie = false;
        StoryDeckHandler.instance.SendEndStoryCard();
    }

}

