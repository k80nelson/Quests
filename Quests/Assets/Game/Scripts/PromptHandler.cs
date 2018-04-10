using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class PromptHandler : NetworkBehaviour {

    #region Singleton
    public static PromptHandler instance;
    #endregion

    #region Message           // To communicate w the server 
    NetworkClient client;

    public class promptMsgType
    {
        public static short MSG = MsgType.Highest + 3;
    };

    public class PromptMsg : MessageBase
    {
        public string header;
        public string body;
    };

    #endregion   

    [SerializeField] Text promptHeader;
    [SerializeField] Text promptMsg;
    [SerializeField] GameObject prompt;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Lobby.LobbyManager mgr = GameObject.FindObjectOfType<Lobby.LobbyManager>();
        client = mgr.client;

        if (client.isConnected)
        {
            client.RegisterHandler(promptMsgType.MSG, ClientOnPromptRcv);
        }
    }


    // Callback for recieving a prompt from the server
    [Client]
    void ClientOnPromptRcv(NetworkMessage msg)
    {
        PromptMsg data = msg.ReadMessage<PromptMsg>();
        localPrompt(data.header, data.body);
    }

    // Sends a prompt to all clients
    [Server]
    public void SendPromptToAll(string header, string body)
    {
        PromptMsg msg = new PromptMsg();
        msg.header = header;
        msg.body = body;
        NetworkServer.SendToAll(promptMsgType.MSG, msg);
    }

    // Sends a prompt to a specific client
    [Server]
    public void SendPromptToClient(GameObject player, string header, string body)
    {
        PromptMsg msg = new PromptMsg();
        msg.header = header;
        msg.body = body;
        NetworkServer.SendToClientOfPlayer(player,promptMsgType.MSG, msg);
    }
    
    // Non-networked local client prompt
    [Client]
    public void localPrompt(string header, string message)
    {
        promptHeader.text = header;
        promptMsg.text = message;
        prompt.SetActive(true);
    }
}
