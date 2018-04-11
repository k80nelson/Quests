using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class SponsorHandler : NetworkBehaviour {

    // ---- SINGLETON ----

    #region Singleton

    public static SponsorHandler instance;

    #endregion

    // ---- MESSAGE TYPES ----

    #region Codes
    public class SponsorStartMsgType
    {
        public static short CODE = MsgType.Highest + 4;
    };

    public class SponsorAcceptMsgType
    {
        public static short CODE = MsgType.Highest + 5;
    };

    public class SponsorDeclineMsgType
    {
        public static short CODE = MsgType.Highest + 6;
    };

    public class SponsorEndMsgType
    {
        public static short CODE = MsgType.Highest + 7;
    };

    public class QuestStartMsgType
    {
        public static short CODE = MsgType.Highest + 8;
    };

    public class QuestAcceptMsgType
    {
        public static short CODE = MsgType.Highest + 9;
    };

    public class QuestDeclineMsgType
    {
        public static short CODE = MsgType.Highest + 10;
    };

    public class QuestInitMsgType
    {
        public static short CODE = MsgType.Highest + 11;
    };

    public class QuestEndStageType
    {
        public static short CODE = MsgType.Highest + 14;
    };

    public class QuestStartBidType
    {
        public static short CODE = MsgType.Highest + 15;
    };

    public class QuestBidType
    {
        public static short CODE = MsgType.Highest + 18;
    };

    public class QuestWinBidType
    {
        public static short CODE = MsgType.Highest + 16;
    };

    public class QuestEndBidType
    {
        public static short CODE = MsgType.Highest + 17;
    };
    public class QuestEndMsgType
    {
        public static short CODE = MsgType.Highest + 12;
    };

    #endregion

    // ---- ATTRIBUTES ----

    #region Networking

    NetworkClient client;

    public class StageMessage : MessageBase
    {
        public int PlayerIndex;
        public int passed;
    }

    public class QuestMessage : MessageBase
    {
        public int shields;
        public int cards;
    }

    #endregion

    [SyncVar] public int CurrQuestIndex;
    BaseCard card;

    [SyncVar]int firstAsked;
    int currentIndex;
    GameObject currObj;

    public SyncListInt questPlayers = new SyncListInt();

    int playersFinished = 0;
    int stagesComplete = 0;
    Dictionary<int, bool> playerStage = new Dictionary<int, bool>();

    int lastBidderPlayer;
    int lastBidder;
    int highestBidderPlayer;



    // ---- INITIALIZATION ----

    #region initialization

    private void Awake()
    {
        // Set up singleton
        instance = this;
    }

    private void Start()
    {
        // Set up callbacks
        Lobby.LobbyManager mgr = GameObject.FindObjectOfType<Lobby.LobbyManager>();
        client = mgr.client;
        if (isClient)
        {
            client.RegisterHandler(SponsorStartMsgType.CODE, OnClientRcvStartSponsor);
            client.RegisterHandler(QuestStartMsgType.CODE, OnRcvStartQuestMsg);
            client.RegisterHandler(QuestInitMsgType.CODE, OnRcvInitQuest);
            client.RegisterHandler(QuestEndStageType.CODE, OnRcvBeginStage);
            client.RegisterHandler(QuestEndMsgType.CODE, OnRcvQuestEnd);
            client.RegisterHandler(QuestStartBidType.CODE, onClientRcvStartBid);
            client.RegisterHandler(QuestWinBidType.CODE, onClientRcvWinBid);

        }
        if (isServer)
        {
            NetworkServer.RegisterHandler(SponsorStartMsgType.CODE, OnServerRcvSponsorStartMsg);
            NetworkServer.RegisterHandler(SponsorDeclineMsgType.CODE, OnServerRcvRefuseSponsor);
            NetworkServer.RegisterHandler(SponsorAcceptMsgType.CODE, OnServerRcvAcceptSponsor);
            NetworkServer.RegisterHandler(SponsorEndMsgType.CODE, OnRcvEndSponsorship);
            NetworkServer.RegisterHandler(QuestAcceptMsgType.CODE, OnRcvAcceptQuest);
            NetworkServer.RegisterHandler(QuestDeclineMsgType.CODE, OnRcvRefuseQuest);
            NetworkServer.RegisterHandler(QuestEndMsgType.CODE, OnRcvEndQuest);
            NetworkServer.RegisterHandler(QuestEndStageType.CODE, OnRcvEndStage);
            NetworkServer.RegisterHandler(QuestStartBidType.CODE, onRcvStartBid);
            NetworkServer.RegisterHandler(QuestBidType.CODE, onRcvBid);
            NetworkServer.RegisterHandler(QuestEndBidType.CODE, onRcvEndBid);
        }
    }

    #endregion

    // ---- COMMUNICATION ----

    #region Start Sponsor Messaging

    [Client] public void SendServerSponsorStartMsg(int index)
    {
        // Tell server to start sponsorship
        questPlayers.Clear();
        Debug.Log("Sending server start sponsorship for card " + index);
        IntegerMessage msg = new IntegerMessage(index);
        client.Send(SponsorStartMsgType.CODE, msg);
    }

    [Server]  void OnServerRcvSponsorStartMsg(NetworkMessage msg)
    {
        // called when server recieves the message send from SendServerSponsorStartMsg
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        int index = data.value;
        CurrQuestIndex = index;
        card = GameManager.instance.dict.findCard(index);
        if (TurnHandler.instance.currPlayerObject != null)
        {
            firstAsked = TurnHandler.instance.currPlayer;
            currentIndex = firstAsked;
            currObj = TurnHandler.instance.currPlayerObject;
            SendClientStartSponsorMsg(currObj, index);
        }
    }

    [Server] void SendClientStartSponsorMsg(GameObject sponsor,  int index)
    {
        // Sends start sponsor message to specific client
        Debug.Log("Sending start sponsorship to client " + sponsor.name);
        IntegerMessage msg = new IntegerMessage(index);
        NetworkServer.SendToClientOfPlayer(sponsor, SponsorStartMsgType.CODE, msg);
    }
    
    [Client] void OnClientRcvStartSponsor(NetworkMessage msg)
    {
        // called when cient recieves the message from SendClientStartSponsorMsg
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        GameSceneManager.instance.showJoinSponsor(data.value);
    }

    #endregion

    #region Join Sponsor Messaging

    [Client] public void SendServerRefuseSponsor()
    {
        // called by clicking no in Join Sponsor
        EmptyMessage msg = new EmptyMessage();
        client.Send(SponsorDeclineMsgType.CODE, msg);
    }

    [Server] void OnServerRcvRefuseSponsor(NetworkMessage msg)
    {
        currentIndex = TurnHandler.instance.playerAfter(currentIndex);
        if (currentIndex == firstAsked)
        {
            destroySponsor();
            TurnHandler.instance.setNextPlayer();
        }
        else
        {
            PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currObj }, "Quest Sponsorship", currObj.name + " refused sponsorship of " + card.name);
            currObj = GameManager.players[currentIndex].gameObject;
            SendClientStartSponsorMsg(GameManager.players[currentIndex].gameObject, CurrQuestIndex);
        }
    }

    [Client] public void SendServerAcceptSponsor()
    {
        EmptyMessage msg = new EmptyMessage();
        client.Send(SponsorAcceptMsgType.CODE, msg);
        GameSceneManager.instance.showSponsorship(CurrQuestIndex);
    }

    [Server] void OnServerRcvAcceptSponsor(NetworkMessage msg)
    {
        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currObj }, "Quest Sponsorship", currObj.name + " accepted sponsorship of " + card.name);
    }

    #endregion

    #region End Sponsor Messaging

    [Client] public void SendServerEndSponsorship()
    {
        EmptyMessage msg = new EmptyMessage();
        client.Send(SponsorEndMsgType.CODE, msg);
    }

    [Server] public void OnRcvEndSponsorship(NetworkMessage msg)
    {
        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currObj }, "Quest Sponsorship", currObj.name + " Finished sponsoring " + card.name);
        firstAsked = currentIndex;
        currentIndex = TurnHandler.instance.playerAfter(currentIndex);
        currObj = GameManager.players[currentIndex].gameObject;
        SendClientStartQuestMsg(currObj);
    }

    #endregion

    #region Join Quest Messaging

    [Server] void SendClientStartQuestMsg(GameObject player)
    {
        EmptyMessage msg = new EmptyMessage();
        NetworkServer.SendToClientOfPlayer(player, QuestStartMsgType.CODE, msg);
    }

    [Client] void OnRcvStartQuestMsg(NetworkMessage msg)
    {
        GameSceneManager.instance.showJoinQuest(CurrQuestIndex);
    }

    [Client] public void SendServerAcceptQuest(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        client.Send(QuestAcceptMsgType.CODE, msg);
    }

    [Server] void OnRcvAcceptQuest(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        Debug.Log(data.value + "Accepts quest");
        questPlayers.Add(data.value);
        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currObj }, "Quest", GameManager.players[currentIndex].name + " has accepted the quest.");
        currentIndex = TurnHandler.instance.playerAfter(currentIndex);
        if (currentIndex == firstAsked)
        {
            startQuest();
        }
        else
        {
            currObj = GameManager.players[currentIndex].gameObject;
            SendClientStartQuestMsg(currObj);
        }
            
    }

    [Client] public void SendServerRefuseQuest(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        client.Send(QuestDeclineMsgType.CODE, msg);
        
    }

    [Server] void OnRcvRefuseQuest(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        Debug.Log(data.value + "Declines quest");
        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { currObj }, "Quest", GameManager.players[currentIndex].name + " has declined the quest.");
        currentIndex = TurnHandler.instance.playerAfter(currentIndex);
        if (currentIndex == firstAsked)
            startQuest();
        else
        {
            currObj = GameManager.players[currentIndex].gameObject;
            SendClientStartQuestMsg(currObj);
        }
    }
    #endregion


    [Server] void sendInitQuest()
    {
        EmptyMessage msg = new EmptyMessage();
        NetworkServer.SendToAll(QuestInitMsgType.CODE, msg);
    }

    [Client] void OnRcvInitQuest(NetworkMessage msg)
    {
        if (questPlayers.Contains(NetPlayerController.LocalPlayer.index))
        {
            GameSceneManager.instance.showQuest(CurrQuestIndex);
        }
        else
        {
            PromptHandler.instance.localPrompt("Quest", "Quest is in progress.");
        }
    }

    [Client] public void SendEndStage(int index, bool passedStage)
    {
        StageMessage msg = new StageMessage();
        msg.PlayerIndex = index;
        msg.passed = (passedStage) ? 1 : 0;
        client.Send(QuestEndStageType.CODE, msg);
    }

    [Server] void OnRcvEndStage(NetworkMessage msg)
    {
        StageMessage data = msg.ReadMessage<StageMessage>();

        playerStage[data.PlayerIndex] = (data.passed == 1);
        playersFinished += 1;
        if (playersFinished >= questPlayers.Count)
        {
            playersFinished = 0;
            stageEnded();
        }
    }

    [Server] void stageEnded()
    {
        stagesComplete += 1;
        List<int> failed = new List<int>();
        List<int> passed = new List<int>();
        foreach (int index in questPlayers)
        {
            if (!playerStage[index])
                failed.Add(index);
            else
            {
                passed.Add(index);
            }
        }
        questPlayers.Clear();
        foreach (int player in passed)
        {
            questPlayers.Add(player);
        }

        if (failed.Count > 0)
        {
            if (passed.Count == 0)
            {
                EndQuest();
                return;
            }
            failPrompt(failed);
        }
        else
        {
            passPrompt();
        }
        if (stagesComplete == ((QuestCard)GameManager.instance.dict.findCard(CurrQuestIndex)).stages)
        {
            EndQuest();
        }
        else
        {
            SendBeginStage(stagesComplete);
        }
    }

    [Server] void failPrompt(List<int> failed)
    {
        string body = GameManager.players[failed[0]].name;
        for(int i=1; i<failed.Count; i++)
        {
            body += " and " + GameManager.players[failed[i]].name;
        }

        body += " failed the quest.";
        PromptHandler.instance.SendPromptToAll("Quest", body);
    }

    [Server] void passPrompt()
    {
        PromptHandler.instance.SendPromptToAll("Quest", "All players passed the quest.");
    }

    [Server] void SendBeginStage(int stageIndex)
    {
        Debug.Log("SENDING NEXT STAFE");
        IntegerMessage msg = new IntegerMessage(stageIndex);
        NetworkServer.SendToAll(QuestEndStageType.CODE, msg);
    }
    
    [Client] void OnRcvBeginStage(NetworkMessage msg)
    {
        Debug.Log("GOT NEXT STAGE");
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();

        int playerIndex = NetPlayerController.LocalPlayer.index;

        if (playerIndex == firstAsked)
        {
            // sponsor
        }
        else if (!(questPlayers.Contains(playerIndex)))
        {
            Debug.Log("NOT IN PLAYERS");
            GameSceneManager.instance.failQuest();
        }
        else
        {
            Debug.Log("SETTING NEXT STAGE");
            GameSceneManager.instance.startQuestStage(data.value);
        }
    }

    [Client] public void sendStartBid(int minBid)
    {
        IntegerMessage msg = new IntegerMessage(minBid);
        client.Send(QuestStartBidType.CODE, msg);
    }

    [Server] void onRcvStartBid(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        int minBid = data.value;
        if (questPlayers.Count == 1)
        {
            minBid = (minBid > 3) ? minBid : 3;
        }
        lastBidder = -1;
        lastBidderPlayer = nextBidder();
        ServerSendStartBid(GameManager.players[lastBidderPlayer].gameObject, minBid);
    }

    [Server] int nextBidder()
    {
        if (questPlayers.Count == 1)
        {
            return -1;
        }
        else
        {
            if (lastBidder >= questPlayers.Count)
            {
                lastBidder = 0;
            }
            else
            {
                lastBidder = (lastBidder + 1) % questPlayers.Count;
            }
        }
        return questPlayers[lastBidder];
    }

    [Server] void ServerSendStartBid(GameObject player, int minBid)
    {
        IntegerMessage msg = new IntegerMessage(minBid);
        NetworkServer.SendToClientOfPlayer(player, QuestStartBidType.CODE,  msg);
    }

    [Client] void onClientRcvStartBid(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        PromptHandler.instance.localPrompt("Quest","Your turn to bid. Minimum bid is " + data.value);
        GameSceneManager.instance.setStageBid(data.value);
    }

    [Server] void sendWinBid(GameObject player)
    {
        PromptHandler.instance.SendPromptToAll("Quest", player.name + " has won the bidding.");

        stagesComplete += 1;
        EmptyMessage msg = new EmptyMessage();
        NetworkServer.SendToClientOfPlayer(player, QuestWinBidType.CODE, msg);
        if (stagesComplete == ((QuestCard)GameManager.instance.dict.findCard(CurrQuestIndex)).stages)
        {
            EndQuest();
        }
        else
        {
            Debug.Log("BIDDING ENDED");
            SendBeginStage(stagesComplete);
        }
    }

    [Client] void onClientRcvWinBid(NetworkMessage msg)
    {
        GameSceneManager.instance.winBid();
    }

    [Client] public void sendBid(int bid)
    {
        StageMessage msg = new StageMessage();
        msg.PlayerIndex = NetPlayerController.LocalPlayer.index;
        msg.passed = bid;
        client.Send(QuestBidType.CODE, msg);
    }
    
    [Server]  void onRcvBid(NetworkMessage msg)
    {
        StageMessage data = msg.ReadMessage<StageMessage>();
        int bid = data.passed;
        int index = data.PlayerIndex;

        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { GameManager.players[index].gameObject }, "Quest", GameManager.players[index].name + " has bid" + bid+" cards.");

        highestBidderPlayer = index;
        
        int newbidderIndex = nextBidder();

        if (newbidderIndex == -1)
            Debug.Log("ERROR");

        ServerSendStartBid(GameManager.players[newbidderIndex].gameObject, bid+1);
    }

    [Client] public void sendEndBid(int playerIndex, int minBid)
    {
        StageMessage msg = new StageMessage();
        msg.PlayerIndex = playerIndex;
        msg.passed = minBid;
        client.Send(QuestEndBidType.CODE, msg);
    }
    
    [Server] void onRcvEndBid(NetworkMessage msg)
    {
        StageMessage data = msg.ReadMessage<StageMessage>();

        PromptHandler.instance.SendPromptToAllExcept(new List<GameObject>() { GameManager.players[data.PlayerIndex].gameObject }, "Quest", GameManager.players[data.PlayerIndex].name + " has dropped out of bidding.");
        
        questPlayers.Remove(data.PlayerIndex);
        if (questPlayers.Count == 1)
        {
            sendWinBid(GameManager.players[highestBidderPlayer].gameObject);
        }
        else
        {
            int nextBidderIndex = nextBidder();
            if (nextBidderIndex == highestBidderPlayer) nextBidderIndex = nextBidder();
            ServerSendStartBid(GameManager.players[nextBidderIndex].gameObject, data.passed);
        }    
    }

    [Server] void SendEndQuest()
    {
        int shields = ((QuestCard)GameManager.instance.dict.findCard(CurrQuestIndex)).stages;
        int cards = NetSponsorModel.instance.numCards + ((QuestCard)GameManager.instance.dict.findCard(CurrQuestIndex)).stages;

        QuestMessage msg = new QuestMessage();
        msg.shields = shields;
        msg.cards = cards;

        if (questPlayers.Count == 0)
        {
            allFailPrompt();
        }
        else
        {
            EndSuccessPrompt();
        }

        NetworkServer.SendToAll(QuestEndMsgType.CODE, msg);

    }

    [Server] void allFailPrompt()
    {
        PromptHandler.instance.SendPromptToAll("Quest", "Quest Complete: All players have failed the quest.");
    }

    [Server] void EndSuccessPrompt()
    {
        string winners = "Quest Complete: " + GameManager.players[questPlayers[0]].name;
        for(int i=1; i< questPlayers.Count; i++)
        {
            winners += ", " + GameManager.players[questPlayers[i]].name;
        }
        winners += " won the quest.";
        PromptHandler.instance.SendPromptToAll("Quest", winners);
    }

    [Client] void OnRcvQuestEnd(NetworkMessage msg)
    {
        QuestMessage data = msg.ReadMessage<QuestMessage>();

        int playerIndex = NetPlayerController.LocalPlayer.index;

        if (playerIndex == firstAsked)
        {
            NetPlayerController.LocalPlayer.drawAdvCards(data.cards );
        }
        else if (!(questPlayers.Contains(playerIndex)))
        {
        }
        else
        {
            NetPlayerController.LocalPlayer.addShield(data.shields);
        }

        GameSceneManager.instance.EndQuest();
    }

    [Client] public void SendServerEndQuest()
    {
        client.Send(QuestEndMsgType.CODE, new EmptyMessage());
    }

    [Server] void OnRcvEndQuest(NetworkMessage msg)
    {
        destroySponsor();
    }
    

    // ---- OTHER ----

    [Server] void startQuest()
    {
        if (questPlayers.Count == 0)
        {
            destroySponsor();
        }
        else
        {
            playersFinished = 0;
            stagesComplete = 0;
            playerStage.Clear();
            sendInitQuest();
        }
    }

    [Server] void EndQuest()
    {
        SendEndQuest();
    }
    
    [Server] void destroySponsor()
    {
        NetSponsorModel.instance.ClearStages();
        CurrQuestIndex = -1;
        card = null;

        firstAsked = -1;
        currentIndex = -1;
        currObj = null;

        questPlayers.Clear();

        playersFinished = 0;
        stagesComplete = 0;
        playerStage.Clear();

        lastBidderPlayer = 0;
        lastBidder = 0;
        highestBidderPlayer = 0;
        StoryDeckHandler.instance.SendEndStoryCard();
        
    }
}


