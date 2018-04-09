using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;
public class PromptHandler : NetworkBehaviour
{
    #region Singleton

    public static PromptHandler instance;

    #endregion
    
    NetworkClient client;

    [SerializeField] Text promptHeader;
    [SerializeField] Text promptBody;
    [SerializeField] GameObject prompt;
    public class promptMsgType
    {
        public static short PRO_MSG = MsgType.Highest + 1;
    };

    public class PromptMessage : MessageBase
    {
        public string header;
        public string body;
    };

    private void Start()
    {
        instance = this;
        GameNetworkManager mgr = GameObject.FindObjectOfType<GameNetworkManager>();
        client = mgr.client;
        
        if (client.isConnected)
        {
            client.RegisterHandler(promptMsgType.PRO_MSG, recievePrompt);
        }
    }

    [Client]
    public void recievePrompt(NetworkMessage msg)
    {
        PromptMessage data = msg.ReadMessage<PromptMessage>();

        promptHeader.text = data.header;
        promptBody.text = data.body;
        prompt.SetActive(true);
    } 

    [Server]
    public void sendPromptToAll(string header, string body)
    {
        PromptMessage msg = new PromptMessage();
        msg.header = header;
        msg.body = body;
        NetworkServer.SendToAll(promptMsgType.PRO_MSG, msg);
    }

    [Server]
    public void sendPromptToUser(string header, string body, int connId)
    {
        PromptMessage msg = new PromptMessage();
        msg.header = header;
        msg.body = body;
        NetworkServer.SendToClient(connId, promptMsgType.PRO_MSG, msg);
    }

    [Server]
    public void sendPromptToUsers(string header, string body, List<int> connIds)
    {
        foreach(int id in connIds)
        {
            sendPromptToUser(header, body, id);
        }
    }

}
