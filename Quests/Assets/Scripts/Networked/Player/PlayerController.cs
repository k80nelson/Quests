using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public PlayerView view;
    public PlayerModel model;
    
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
    void CmdRegisterSelf()
    {
        if (!model.registered)
            GameController.instance.addPlayer(this);
        RpcSetName();
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
    }

    [ClientRpc]
    void RpcAddCard(GameObject card)
    {
        card.transform.SetParent(view.cardSpawnPoint);
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
        CmdDrawAdvCards(12);
        view.showCardArea();
        CmdRegisterSelf();
    }
    
}
