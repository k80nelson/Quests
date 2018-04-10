using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class QuestHandler : NetworkBehaviour {

    #region Singleton

    public static QuestHandler instance;

    #endregion

    NetworkClient client;

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

    public class SponsorMessage : MessageBase
    {
        public int numStages;
        public int index;
    };
    
    // Set up singleton
    private void Awake()
    {
        instance = this;
    }

    // Set up callbacks
    private void Start()
    {
        Lobby.LobbyManager mgr = GameObject.FindObjectOfType<Lobby.LobbyManager>();
        client = mgr.client;
        if (isClient)
        {
            client.RegisterHandler(SponsorStartMsgType.CODE, OnClientRcvStartSponsor);
        }
        if (isServer)
        {
            NetworkServer.RegisterHandler(SponsorStartMsgType.CODE, OnServerRcvSponsorStartMsg);
        }
    }

    // Tell server to start sponsorship
    [Client]
    public void SendServerSponsorStartMsg(int stages, int index)
    {
        Debug.Log("Sending server start sponsorship for card " + index);
        SponsorMessage msg = new SponsorMessage();
        msg.numStages = stages;
        msg.index = index;
        client.Send(SponsorStartMsgType.CODE, msg);
    }

    // called when server recieves the message send from SendServerSponsorStartMsg
    [Server]
    void OnServerRcvSponsorStartMsg(NetworkMessage msg)
    {
        SponsorMessage data = msg.ReadMessage<SponsorMessage>();
        int stages = data.numStages;
        int index = data.index;
        Debug.Log("Starting sponsorship for card " + index + " with stages " + stages);
        if (TurnHandler.instance.currPlayerObject != null)
        {
            SendClientStartSponsorMsg(TurnHandler.instance.currPlayerObject, stages, index);
        }
    }

    // Sends start sponsor message to specific client
    [Server]
    void SendClientStartSponsorMsg(GameObject sponsor, int stages, int index)
    {
        Debug.Log("Sending start sponsorship to client " + sponsor.name);
        SponsorMessage msg = new SponsorMessage();
        msg.numStages = stages;
        msg.index = index;
        NetworkServer.SendToClientOfPlayer(sponsor, SponsorStartMsgType.CODE, msg);
    }
    
    // called when cient recieves the message from SendClientStartSponsorMsg
    [Client]
    void OnClientRcvStartSponsor(NetworkMessage msg)
    {
        SponsorMessage data = msg.ReadMessage<SponsorMessage>();
        Debug.Log("Got Start Sponsor message for quest " + data.index + " with " + data.numStages + " stages.");
    }


}


