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

    [SerializeField] Transform storyCardSpawnPos;
    [SerializeField] GameObject storyCardPrefab;
    [SerializeField] Button btn;

    GameObject currCard;

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
        if (isServer)
            card.applyCard();

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
        int card = DeckController.instance.drawStoryCard();
        SendStoryCard(card);
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
        Debug.Log("Got card " + data.value);
        spawnCard(data.value);
    }
    
}
