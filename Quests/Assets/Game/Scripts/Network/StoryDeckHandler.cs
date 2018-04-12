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

    // ---- ATTRIBUTES ----

    NetworkClient client;
    const short StoryMsg = MsgType.Highest + 2;
    const short EndStoryMsg = MsgType.Highest + 13;

    [SerializeField] Transform storyCardSpawnPos;
    [SerializeField] GameObject storyCardPrefab;
    [SerializeField] Button btn;

    GameObject currCard;
    int currIndex;

    // ---- INITIALIZATION ----

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
            client.RegisterHandler(EndStoryMsg, OnEndStoryRcv);
            
        }
    }
    
    // ---- CLIENT NON NETWORKED METHODS ----

    [Client] public void DrawCard()
    {
        // Calls SendAskStoryCardMsg() which asks the server for a card
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

    [Client] void spawnCard(int num)
    {
        // Called from ClientRcvStoryCard when a client gets a card index from the server
        currCard = Instantiate(storyCardPrefab, storyCardSpawnPos);
        Card card = currCard.GetComponent<Card>();
        card.setCard(GameManager.instance.dict.findCard(num));
        currCard.tag = "CurrStory";
        if (isServer)
            card.applyCard();
        else if (!isServer && card.card is EventCard)
        {
            card.applyCard();
        }
    }

    [Client] void destroyCard()
    {
        Destroy(currCard);
    }

    // ---- NETWORKING ----

    [Client]  public void SendAskStoryCardMsg()
    {
        // Asks the server for a card index
        EmptyMessage msg = new EmptyMessage();
        client.Send(StoryMsg, msg);
    }

    [Server] public void ServerRcvAskStoryCard(NetworkMessage msg)
    {
        // Called when the server recieves a request for a card
        currIndex = DeckController.instance.drawStoryCard();
        SendStoryCard(currIndex);
    }

    [Server] public void SendStoryCard(int index)
    {
        // Sends a card index to all clients
        IntegerMessage msg = new IntegerMessage(index);
        NetworkServer.SendToAll(StoryMsg, msg);
    }

    [Client] public void ClientRcvStoryCard(NetworkMessage msg)
    {
        // Called when a client recieves a card index from the server
        IntegerMessage data = msg.ReadMessage<IntegerMessage>();
        Debug.Log("[StoryDeckHandler.cs] Recieved story card: " + GameManager.instance.dict.findCard(data.value));
        spawnCard(data.value);
    }

    [Server] public void SendEndStoryCard()
    {
        DeckController.instance.discardStoryCard(currIndex);
        EmptyMessage msg = new EmptyMessage();
        NetworkServer.SendToAll(EndStoryMsg, msg);
    }

    [Client] void OnEndStoryRcv(NetworkMessage msg)
    {
        destroyCard();
    }
    
}
