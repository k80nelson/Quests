using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class StoryDeckHandler : NetworkBehaviour {

    #region Singleton
    public static StoryDeckHandler instance;
    #endregion

    #region Message
    const short StoryMsg = MsgType.Highest + 2;
    NetworkClient client;

    [Client]
    public void SendAskStoryCardMsg()
    {
        EmptyMessage msg = new EmptyMessage();
        client.Send(StoryMsg, msg);
    }

    [Server]
    public void SendStoryCard(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        NetworkServer.SendToAll(StoryMsg,msg);
    }

    [Client]
    public void ClientRcvStoryCard(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        Debug.Log("Got card " + data.value);
        spawnCard(data.value);
    }

    [Server]
    public void ServerRcvAskStoryCard(NetworkMessage msg)
    {
        int card = DeckController.instance.drawStoryCard();
        SendStoryCard(card);
    }
    #endregion

    [SerializeField] Transform storyCardSpawnPos;
    [SerializeField] GameObject storyCardPrefab;

    GameObject currCard;

    private void Start()
    {
        Lobby.LobbyManager mgr = GameObject.FindObjectOfType<Lobby.LobbyManager>();
        client = mgr.client;
        if (isServer)
        {
            NetworkServer.RegisterHandler(StoryMsg, ServerRcvAskStoryCard);
        }
        if (isClient)
        {
            client.RegisterHandler(StoryMsg, ClientRcvStoryCard);
        }
    }

    [Client]
    void spawnCard(int num)
    {
        currCard = Instantiate(storyCardPrefab, storyCardSpawnPos);
        currCard.GetComponent<Card>().setCard(GameManager.instance.dict.findCard(num));
    }

}
