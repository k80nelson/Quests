using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetPlayerModel))]
[RequireComponent(typeof(PlayerView))]
public class NetPlayerController : NetworkBehaviour {

    // Static variable. Calling NetPlayerController.LocalPlayer 
    // from any script will always find the local PlayerController
    public static NetPlayerController LocalPlayer;  

    protected PlayerView _view;      
    protected NetPlayerModel _model;


    [SyncVar (hook = "OnTurnChg")]
    public bool isTurn = false;          // true when they are the currPlayer

    [SyncVar]
    public bool isActive = false;        // true when they are an active player

    [SyncVar] public string playerName;
    [SyncVar] public int index;

    protected bool _wasInit = false;     // fixes a race condition


    // ------------ INITIALIZATION ----------------- 
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
            StartCoroutine(waitAndAddCards());  // Need to wait in case things aren't fully initialized
        }
    }
    
    public void Init()
    {
        if (_wasInit) return;  // return if already initialized

        gameObject.name = playerName;
        _view.initStats(isLocalPlayer);  // add player stats to the screen

        if (isLocalPlayer)
        {
            _view.initLocal();  // makes the bottom card area
            Cmd_initModel();    // initializes the Model
        }

        if (!isServer)  // NON-HOST clients only
        {
            _view.updateRankText(_model.rankInt);
            _view.updateShieldText(_model.shields);
            _view.updateCardText(_model.cards);
        }
        _wasInit = true;
    }

    // Model should only ever be changed on the server
    [Command]
    void Cmd_initModel()
    {
        _model.Init();
    }

    // Waiting coroutine
    IEnumerator waitAndAddCards()
    {
        if (!isLocalPlayer) yield break;
        yield return new WaitForSeconds(0.5f);
        if (isLocalPlayer && isClient)
        {
            Cmd_DrawAdv(12);
            Cmd_Ready();
        }
    }

    // Called when everything is fully instantiated. Lets the server start the game
    [Command]
    void Cmd_Ready()
    {
        GameManager.instance.addReady();
    }

    // ------------- STATE MANIPULATION ------------------

    // ----- CARDS AND ALLIES -----

    #region Cards
    // -- HAND --

    // public draw card method -> only runs on local player
    public void drawAdvCards(int num)
    {
        if (!isLocalPlayer)
            return;
        Cmd_DrawAdv(num);
    }

    // draw adv needs to run on the SERVER -> deck controller and both
    // decks are on the server only
    [Command]
    void Cmd_DrawAdv(int num)
    {
        List<int> indices = DeckController.instance.drawAdvCards(num);
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

    // Only runs on the local client
    public void discard(GameObject card)
    {
        if (!isLocalPlayer) return;
        _view.destroyCard(card);
        Cmd_discard(card.GetComponent<Card>().card.index);
    }

    // Runs on the server
    [Command]
    void Cmd_discard(int index)
    {
        _model.removeCard(GameManager.instance.dict.findCard(index) as AdventureCard);
        DeckController.instance.discardAdvCard(index);
    }

    // -- ALLIES --

    // TO BE IMPLEMENTED
    public void addAlly()
    {
        if (!isLocalPlayer)
            return;

    }

    // discards and destroys all allies
    public void discardAllies()
    {
        if (!isLocalPlayer)
            return;
        _view.destroyAllies();
        Cmd_discardAllies();
    }

    // removes allies from model n discards them
    [Command]
    void Cmd_discardAllies()
    {
        List<AdventureCard> allies = _model.removeAllies();
        foreach(AdventureCard ally in allies)
        {
            DeckController.instance.discardAdvCard(ally.index);
        }
    }

    #endregion

    // ----- SHIELDS AND RANK -----
    // returns true when players have more cards than they should
    public bool isOverMax()
    {
        return (_model.cards > NetPlayerModel.maxCards);
    }
    
    // Called from TurnHandler.cs -> tells the player it is their turn to draw a card
    public void setStartTurn()
    {
        if (!isLocalPlayer) return;
        Cmd_SetTurn();
    }

    // called when you press end turn
    public void unsetTurn()
    {
        if (!isLocalPlayer) return;
        if (!isTurn) return;
        Cmd_UnsetTurn();
    }
    
    [Server]
    public void setActive()
    {
        isActive = true;
    }

    [Server]
    public void unSetActive()
    {
        isActive = false;
    }

    [Command]
    void Cmd_SetTurn()
    {
        this.isTurn = true;
    }
    
    [Command]
    void Cmd_UnsetTurn()
    {
        this.isTurn = false;
    }
    
    // This is called when the MAIN GAME LOOP changes CURRENT PLAYER. 
    // Should only be called when its their turn to draw a card
    void OnTurnChg(bool newVal)
    {
        this.isTurn = newVal;
        if (isLocalPlayer && isTurn)    // IT IS THIS CLIENTS TURN -> ACTIVATE THEIR UI
        {
            TurnHandler.instance.showTurnUI();
        }
        if (isLocalPlayer && !isTurn)   // THIS CLIENTS TURN HAS JUST ENDED -> DISABLE THEIR UI
        {
            TurnHandler.instance.unShowTurnUI();
        }
    }
    


    public void removeShields(int num)
    {
        if (!isLocalPlayer)
            return;
        Cmd_removeShields(num);
    }
    
    // removes shields 
    public void removeShields(bool forCurrentPlayer, int num)
    {
        if (!isLocalPlayer)
            return;
        if (forCurrentPlayer && isTurn)
        {
            // if forCurrentPlayer is true, remove if this.isTurn is true -> plague removes for current player
            removeShields(num);
        } 
        else if (!forCurrentPlayer && !isTurn)
        {
            // if forCurrentPlayer is false, remove if this.isTurn is false -> pox removes for all but the current player
            removeShields(num);
        }
    }

    public void addShield(int num)
    {
        if (!isLocalPlayer)
            return;
        _model.addShields(num);
    }

    [Command]
    void Cmd_removeShields(int num)
    {
        _model.removeShields(num);
    }

    public int getRank()
    {
        return _model.rankInt;
    }

    
    private void OnDestroy()
    {
        GameManager.players.Remove(this);
    }
    
}
