using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class TurnHandler : NetworkBehaviour {

    const short TurnMsg = MsgType.Highest + 1;
    NetworkClient client;

    [SerializeField] GameObject waitOverlay;
    

    private void Start()
    {
        GameNetworkManager mgr = GameObject.FindObjectOfType<GameNetworkManager>();
        client = mgr.client;
        if (client.isConnected)
        {
            client.RegisterHandler(TurnMsg, clientRecieveTurnMsg);
        }
        if (isServer)
        {
            NetworkServer.RegisterHandler(TurnMsg, serverRecieveTurnMsg);
        }
    }
    
    [Server]
    public void sendTurnToClients(int playerIndex)
    {
        var msg = new IntegerMessage(playerIndex);
        NetworkServer.SendToAll(TurnMsg, msg);
    }

    [Client]
    public void sendTurnToServer(int playerIndex)
    {
        var msg = new IntegerMessage(playerIndex);
        client.Send(TurnMsg, msg);
    }

    [Server]
    public void serverRecieveTurnMsg(NetworkMessage msg)
    {
        var message = msg.ReadMessage<IntegerMessage>();
        Debug.Log(message.value);
    }

    [Client]
    public void clientRecieveTurnMsg(NetworkMessage msg)
    {
        var message = msg.ReadMessage<IntegerMessage>();
        Debug.Log(message.value);
    }

}
