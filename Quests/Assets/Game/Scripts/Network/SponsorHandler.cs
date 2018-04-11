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

    public class QuestEndMsgType
    {
        public static short CODE = MsgType.Highest + 11;
    };

    #endregion

    #region Messages

    public class SponsorMessage : MessageBase
    {
        public int numStages;
        public int index;
    };

    #endregion

    // ---- ATTRIBUTES ----

    #region Networking

    NetworkClient client;

    #endregion

    [SyncVar] public int CurrQuestIndex;
    BaseCard card;

    int firstAsked;
    int currentIndex;
    GameObject currObj;

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
        }
        if (isServer)
        {
            NetworkServer.RegisterHandler(SponsorStartMsgType.CODE, OnServerRcvSponsorStartMsg);
            NetworkServer.RegisterHandler(SponsorDeclineMsgType.CODE, OnServerRcvRefuseSponsor);
            NetworkServer.RegisterHandler(SponsorAcceptMsgType.CODE, OnServerRcvAcceptSponsor);
        }
    }

    #endregion

    // ---- COMMUNICATION ----

    #region Start Sponsor Messaging

    [Client] public void SendServerSponsorStartMsg(int index)
    {
        // Tell server to start sponsorship
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

    // ---- OTHER ----

    [Server] void startSponsor()
    {

    }

    [Server] void destroySponsor()
    {
        CurrQuestIndex = -1;
        currentIndex = -1;
        firstAsked = -1;
        StoryDeckHandler.instance.SendEndStoryCard();
    }
}


