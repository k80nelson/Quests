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
            CmdDrawAdv(12);
        }
    }

    [Command]
    void CmdDrawAdv(int num)
    {
        List<int> indices = DeckController.instance.drawAdvCards(12);
        foreach(int index in indices)
        {
            model.hand.Add(GameController.instance.cardDict.findCard(index) as AdventureCard);
            RpcAddCard(index);
            if (onCardsChangedCallback != null)
            {
                onCardsChangedCallback.Invoke();
            }
        }
    }
    

    [ClientRpc]
    void RpcAddCard(int index)
    {
        if (!isLocalPlayer) return;
        AdventureCard card = GameController.instance.cardDict.findCard(index) as AdventureCard;
        view.createCard(card);
        if (onCardsChangedCallback != null)
        {
            onCardsChangedCallback.Invoke();
        }
    }
    

    public void drawAdvCards(int num)
    {
        CmdDrawAdv(12);
    }

    public void discardCard(GameObject card)
    {
        if (!isLocalPlayer) return;
        view.destroyCard(card);
        Cmd_discardCard(card.GetComponent<Card>().card.index);
    }

    [Command]
    void Cmd_discardCard(int num)
    {
        model.hand.remove(GameController.instance.cardDict.findCard(num) as AdventureCard);
        if (onCardsChangedCallback != null)
        {
            onCardsChangedCallback.Invoke();
        }
        DeckController.instance.discardAdvCard(num);
    }
    
    /*
    [Command]
    void CmdDrawAdvCards(int numToDraw)
    {
        Transform parent = view.cardSpawnPoint;
        List<GameObject> cards = DeckController.instance.drawAdvCards(numToDraw, parent);
        foreach(GameObject card in cards)
        {
            Debug.Log(card.name);
            NetworkServer.Spawn(card);
            RpcAddCard(card);
        }
        if (onCardsChangedCallback != null)
            onCardsChangedCallback.Invoke();
    }

    [ClientRpc]
    void RpcAddCard(GameObject card)
    {
        Debug.Log("Adding card to " + model.index);
        card.transform.SetParent(view.cardSpawnPoint);
        model.hand.Add(card.GetComponent<Card>().card as AdventureCard);
    }

    [ClientRpc]
    void RpcSetName()
    {
        setName();
    }

    void setName()
    {
        gameObject.name = "Player " + (model.index + 1);
    }

    // Local player only initialization
    public override void OnStartLocalPlayer()
    {
        view.showCardArea();
        CmdDrawAdvCards(12);
    }*/
    
}
