using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class StoryDeckHandler : NetworkBehaviour {

    #region Singleton
    public static StoryDeckHandler instance;
    #endregion

    #region  Message           // To communicate w the server

    const short StoryMsg = MsgType.Highest + 2;
    NetworkClient client;

    #endregion

    [SerializeField] Transform storyCardSpawnPos;
    [SerializeField] GameObject storyCardPrefab;
    [SerializeField] Button btn;

    GameObject currCard;

    private void Awake()
    {
        instance = this;
    }

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


    // Calls SendAskStoryCardMsg() which asks the server for a card
    [Client]
    public void DrawCard()
    {
        if (NetPlayerController.LocalPlayer.isOverMax())
        {
            PromptHandler.instance.localPrompt("Story Deck", "You must discard some cards.");
        }
        else
        {
            btn.interactable = false;
            SendAskStoryCardMsg();
        }
    }
    
    // Asks the server for a card index
    [Client]
    public void SendAskStoryCardMsg()
    {
        EmptyMessage msg = new EmptyMessage();
        client.Send(StoryMsg, msg);
    }

    // Called when the server recieves a request for a card
    [Server]
    public void ServerRcvAskStoryCard(NetworkMessage msg)
    {
        int card = DeckController.instance.drawStoryCard();
        SendStoryCard(card);
    }

    // Sends a card index to all clients
    [Server]
    public void SendStoryCard(int index)
    {
        IntegerMessage msg = new IntegerMessage(index);
        NetworkServer.SendToAll(StoryMsg, msg);
    }

    // Called when a client recieves a card index from the server
    [Client]
    public void ClientRcvStoryCard(NetworkMessage msg)
    {
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        Debug.Log("Got card " + data.value);
        spawnCard(data.value);
    }

    // Called from ClientRcvStoryCard when a client gets a card index from the server
    [Client]
    void spawnCard(int num)
    {
        currCard = Instantiate(storyCardPrefab, storyCardSpawnPos);
        currCard.GetComponent<Card>().setCard(GameManager.instance.dict.findCard(num));
    }

}
