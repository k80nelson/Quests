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

    // ---- NETWORKING TYPES ----

    public class promptMsgType
    {
        public static short MSG = MsgType.Highest + 3;
    };

    public class PromptMsg : MessageBase
    {
        public string header;
        public string body;
    };

    // ---- ATTRIBUTES ----

    NetworkClient client;
    
    [SerializeField] Text promptHeader;
    [SerializeField] Text promptMsg;
    [SerializeField] GameObject prompt;

    // ---- INITIALIZATION ----

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

    // ---- COMMUNICATION ----

    [Client] void ClientOnPromptRcv(NetworkMessage msg)
    {
        // Callback for recieving a prompt from the server
        PromptMsg data = msg.ReadMessage<PromptMsg>();
        localPrompt(data.header, data.body);
    }

    [Server] public void SendPromptToAll(string header, string body)
    {
        // Sends a prompt to all clients
        PromptMsg msg = new PromptMsg();
        msg.header = header;
        msg.body = body;
        NetworkServer.SendToAll(promptMsgType.MSG, msg);
    }

    [Server] public void SendPromptToClient(GameObject player, string header, string body)
    {
        // Sends a prompt to a specific client
        PromptMsg msg = new PromptMsg();
        msg.header = header;
        msg.body = body;
        NetworkServer.SendToClientOfPlayer(player,promptMsgType.MSG, msg);
    }
    
    [Client] public void localPrompt(string header, string message)
    {
        // Non-networked local client prompt
        promptHeader.text = header;
        promptMsg.text = message;
        prompt.SetActive(true);
    }
}
