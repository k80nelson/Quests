using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public PlayerView view;
    public PlayerModel model;

    public delegate void OnCardsChanged();
    public OnCardsChanged onCardsChangedCallback;
    
    // used for initialization
    private void Awake()
    {
        view = GetComponent<PlayerView>();
        model = GetComponent<PlayerModel>();
    }
    void Start()
    {
        gameObject.transform.SetParent(GameController.instance.transform);
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 200);
        gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
    }
    
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
    }
    
}
