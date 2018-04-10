using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetPlayerModel))]
[RequireComponent(typeof(PlayerView))]
public class NetPlayerController : NetworkBehaviour {

    public static NetPlayerController LocalPlayer;

    protected PlayerView _view;
    protected NetPlayerModel _model;


    [SyncVar (hook = "OnTurnChg")]
    public bool isActive = false; // true when it is that player's turn. Allows things to be interacted with

    [SyncVar] public string playerName;
    [SyncVar] public int index;

    protected bool _wasInit = false;  // fixes a race condition.

    private void Awake()
    {
        GameManager.players.Add(this);
        _view = GetComponent<PlayerView>();
        _model = GetComponent<NetPlayerModel>();
    }

    private void Start()
    {
        if (GameManager.instance != null)
        {
            Init();
        }
        if (isLocalPlayer && isClient)
        {
            LocalPlayer = this;
            StartCoroutine(waitAndAddCards());
        }
    }

    public void Init()
    {
        if (_wasInit) return;
        gameObject.name = playerName;
        _view.initStats(isLocalPlayer);
        if (isLocalPlayer)
        {
            _view.initLocal();
            Cmd_initModel();
        }
        if (!isServer)
        {
            _view.updateRankText(_model.rankInt);
            _view.updateShieldText(_model.shields);
            _view.updateCardText(_model.cards);
        }
        _wasInit = true;
    }

    [Command]
    void Cmd_initModel()
    {
        _model.Init();
    }

    IEnumerator waitAndAddCards()
    {
        yield return new WaitForSeconds(0.5f);
        if (isLocalPlayer && isClient)
        {
            Cmd_DrawAdv(12);
            Cmd_Ready();
        }
    }

    [Command]
    void Cmd_Ready()
    {
        GameManager.instance.addReady();
    }

    public void setTurn()
    {
        if (!isLocalPlayer) return;
        Cmd_SetTurn();
    }

    public void unsetTurn()
    {
        if (!isLocalPlayer) return;
        if (!isActive) return;
        Cmd_UnsetTurn();
    }

    [Command]
    void Cmd_SetTurn()
    {
        this.isActive = true;
    }
    
    [Command]
    void Cmd_UnsetTurn()
    {
        this.isActive = false;
    }
    
    void OnTurnChg(bool newVal)
    {
        this.isActive = newVal;
        if (isLocalPlayer && isActive)    // IT IS THIS CLIENTS TURN -> ACTIVATE THEIR UI
        {
            Debug.Log("ENABLE SHIT");
        }
        if (isLocalPlayer && !isActive)   // THIS CLIENTS TURN HAS JUST ENDED -> DISABLE THEIR UI
        {
            Debug.Log("DISABLE SHIT");
        }
    }
    
    
    [Command]
    void Cmd_DrawAdv(int num)
    {
        List<int> indices = DeckController.instance.drawAdvCards(12);
        foreach (int index in indices)
        {
            _model.AddCard(GameManager.instance.dict.findCard(index) as AdventureCard);
            Rpc_AddCard(index);
        }
    }

    // Called on server, runs on client
    [ClientRpc]
    void Rpc_AddCard(int index)
    {
        if (!isLocalPlayer) return;
        AdventureCard card = GameManager.instance.dict.findCard(index) as AdventureCard;
        _view.addCard(card);
    }

    public void discard(GameObject card)
    {
        if (!isLocalPlayer) return;
        _view.destroyCard(card);
        Cmd_discard(card.GetComponent<Card>().card.index);
    }

    [Command]
    void Cmd_discard(int index)
    {
        _model.removeCard(GameManager.instance.dict.findCard(index) as AdventureCard);
        DeckController.instance.discardAdvCard(index);
    }

    private void OnDestroy()
    {
        GameManager.players.Remove(this);
    }
    
}
