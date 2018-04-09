using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {
    
    public PlayerView view;

    // ONLY CHANGE MODEL ON THE SERVER !!!!!
    public PlayerModel model;

    public delegate void OnCardsChanged();
    public OnCardsChanged onCardsChangedCallback;

    // used for initialization
    private void Awake()
    {
        view = GetComponent<PlayerView>();
        model = GetComponent<PlayerModel>();
    }

    // used to initialize anything the LOCAL PLAYER needs BEFORE SCENE IS LOADED
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        gameObject.tag = "LocalPlayer";
    }
    
    // used to instantiate 
    void Start()
    {
        if (isLocalPlayer && isClient)
        {
            // here is where you initialize anything the LOCAL PLAYER needs WHEN SCENE IS LOADED
            view.makeCardArea();
            GameController.instance.playerLoaded();
            StartCoroutine(waitForLoad());
        }
    }

    IEnumerator waitForLoad()
    {
        yield return new WaitForSeconds(0.2f);
        Cmd_getStats();
    }

    [Command]
    void Cmd_getStats()
    {
        GameController.instance.view.pollStats();
        GameController.instance.view.FindStats();
    }

    public void readyPlayer()
    {
        Cmd_readyPlayer();
        Cmd_DrawAdv(12);
        StartCoroutine(waitForLoad());
    }

    [Command]
    void Cmd_readyPlayer()
    {
        GameController.instance.addReady();
    }
    
    // Called on client, runs on server
    [Command]
    void Cmd_DrawAdv(int num)
    {
        List<int> indices = DeckController.instance.drawAdvCards(12);
        foreach(int index in indices)
        {
            model.hand.Add(GameController.instance.cardDict.findCard(index) as AdventureCard);
            Rpc_AddCard(index);
        }
        if (onCardsChangedCallback != null)
        {
            onCardsChangedCallback.Invoke();
        }
    }
    
    // Called on server, runs on client
    [ClientRpc]
    void Rpc_AddCard(int index)
    {
        if (!isLocalPlayer) return;
        AdventureCard card = GameController.instance.cardDict.findCard(index) as AdventureCard;
        view.createCard(card);
        if (onCardsChangedCallback != null)
        {
            onCardsChangedCallback.Invoke();
        }
    }
    
    // public add cards method
    public void drawAdvCards(int num)
    {
        Cmd_DrawAdv(12);
    }

    // public method to discard a card GameObject
    public void discardCard(GameObject card)
    {
        if (!isLocalPlayer) return;
        view.destroyCard(card);
        Cmd_discardCard(card.GetComponent<Card>().card.index);
    }

    // Runs on the server using card's global index
    [Command]
    void Cmd_discardCard(int num)
    {
        model.hand.remove(GameController.instance.cardDict.findCard(num) as AdventureCard);
        if (onCardsChangedCallback != null)
        {
            onCardsChangedCallback.Invoke();
        }
        DeckController.instance.discardAdvCard(num);
        Rpc_discardCard();
    }

    // just calls the update cards callbacks
    [ClientRpc]
    void Rpc_discardCard()
    {
        if (onCardsChangedCallback != null)
        {
            onCardsChangedCallback.Invoke();
        }
    }
    
}
