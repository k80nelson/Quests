using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

[RequireComponent(typeof(NetPlayerModel))]
[RequireComponent(typeof(PlayerView))]
public class NetPlayerController : NetworkBehaviour {

    // ----------- ATTRIBUTES ----------------------

    #region Attributes

    // Static variable. Calling NetPlayerController.LocalPlayer 
    // from any script will always find the local PlayerController
    public static NetPlayerController LocalPlayer;  


    protected PlayerView _view;      
    protected NetPlayerModel _model;
    [SyncVar] public string playerName;
    [SyncVar] public int index;
    protected bool _wasInit = false;     // fixes a race condition

    [SyncVar (hook = "OnTurnChg")] public bool isTurn = false; // true when they are the currPlayer
    [SyncVar] public bool isActive = false;        // true when they are an active player
    public Transform cardArea;

    #endregion

    // ------------ INITIALIZATION ----------------- 

    #region Initialization

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
            cardArea = _view.cardSpawnPos;
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

    [Command] void Cmd_initModel()
    {
        // Model should only ever be changed on the server
        _model.Init();
    }

    IEnumerator waitAndAddCards()
    {
        // Waiting coroutine
        if (!isLocalPlayer) yield break;
        yield return new WaitForSeconds(0.5f);
        if (isLocalPlayer && isClient)
        {
            Cmd_DrawAdv(12);
            Cmd_Ready();
        }
    }

    
    [Command] void Cmd_Ready()
    {
        // Called when everything is fully instantiated. Lets the server start the game
        GameManager.instance.addReady();
    }

    #endregion

    // ------------- STATE MANIPULATION ------------

    // --- TURNS ---

    #region Turns
        
    public void setStartTurn()
    {
        // Called from TurnHandler.cs -> tells the player it is their turn to draw a card
        if (!isLocalPlayer) return;
        Cmd_SetTurn();
    }

    public void unsetTurn()
    {
        // called when you press end turn
        if (!isLocalPlayer) return;
        if (!isTurn) return;
        Cmd_UnsetTurn();
    }

    [Server] public void setActive()
    {
        isActive = true;
    }

    [Server] public void unSetActive()
    {
        isActive = false;
    }

    [Command] void Cmd_SetTurn()
    {
        this.isTurn = true;
    }

    [Command] void Cmd_UnsetTurn()
    {
        this.isTurn = false;
    }

    void OnTurnChg(bool newVal)
    {
        // This is called when the MAIN GAME LOOP changes CURRENT PLAYER. 
        // Should only be called when its their turn to draw a card
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

    #endregion

    // --- CARDS AND ALLIES ---

    #region Cards

    // -- HAND --

    public void drawAdvCards(int num)
    {
        // public draw card method -> only runs on local player
        if (!isLocalPlayer)
            return;
        Cmd_DrawAdv(num);
    }

    [Command] void Cmd_DrawAdv(int num)
    {
        // draw adv needs to run on the SERVER -> deck controller and both
        // decks are on the server only
        List<int> indices = DeckController.instance.drawAdvCards(num);
        foreach (int index in indices)
        {
            _model.AddCard(GameManager.instance.dict.findCard(index) as AdventureCard);
            Rpc_AddCard(index);
        }
    }
    
    [ClientRpc] void Rpc_AddCard(int index)
    {
        // Called on server, runs on client
        if (!isLocalPlayer) return;
        AdventureCard card = GameManager.instance.dict.findCard(index) as AdventureCard;
        _view.addCard(card);
    }
    
    public void discard(GameObject card)
    {
        // Only runs on the local client
        if (!isLocalPlayer) return;
        Cmd_discard(card.GetComponent<Card>().card.index);
        _view.destroyCard(card);
        
    }

    public void discardBid(GameObject card)
    {
        if (!isLocalPlayer) return;
        Cmd_discard(card.GetComponent<Card>().card.index);
        Destroy(card);
        
    }

    public void removeCard(int card)
    {
        Cmd_removeCard(card);
    }

    public void discardCard(int card)
    {
        Cmd_discard(card);
    }

    public int getBP()
    {
        return _model.bp;
    }
    
    [Command] void Cmd_discard(int index)
    {   
        // Runs on the server
        _model.removeCard(GameManager.instance.dict.findCard(index) as AdventureCard);
        DeckController.instance.discardAdvCard(index);
    }

    [Command] void Cmd_removeCard(int index)
    {
        _model.removeCard(GameManager.instance.dict.findCard(index) as AdventureCard);
    }

    // -- ALLIES --
    
    public void addAlly(AdventureCard ally)
    {
        // TO BE IMPLEMENTED
        if (!isLocalPlayer)
            return;
        Cmd_AddAlly(ally.index);
    }

    [Command] void Cmd_AddAlly(int index)
    {
        _model.AddAlly(GameManager.instance.dict.findCard(index) as AdventureCard);
    }

    public void discardAllies()
    {
        // discards and destroys all allies
        if (!isLocalPlayer)
            return;
        _view.destroyAllies();
        Cmd_discardAllies();
    }

    [Command] void Cmd_discardAllies()
    {
        // removes allies from model n discards them
        List<AdventureCard> allies = _model.removeAllies();
        foreach(AdventureCard ally in allies)
        {
            DeckController.instance.discardAdvCard(ally.index);
        }
    }

    #endregion

    // --- SHIELDS ---

    #region Shields

    public void addShield(int num)
    {
        // public add shields to local player
        if (!isLocalPlayer)
            return;
        Cmd_addShields(num);
    }

    [Command] void Cmd_addShields(int num)
    {
        _model.addShields(num);
    }
    
    public void removeShields(int num)
    {
        // public remove shields function
        if (!isLocalPlayer)
            return;
        Cmd_removeShields(num);
    }

    public void removeShields(bool forCurrentPlayer, int num)
    {
        // public removes shields function that checks if its your turn
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

    [Command] void Cmd_removeShields(int num)
    {
        _model.removeShields(num);
    }

    #endregion
    
    // ------------- STATE VIEWING -----------------

    #region Getters
    public bool isOverMax()
    {
        // returns true when players have more cards than they should
        return (_model.cards > NetPlayerModel.maxCards);
    }

    public int getRank()
    {
        return _model.rankInt;
    }

    public int getShields()
    {
        return _model.shields;
    }

    public int getNumCards()
    {
        return _model.cards;
    }

    public List<int> getAllies()
    {
        return _model.getAllies();
    }

    #endregion

    // ------------ QUESTS, SPONSORSHIPS -----------


    public void playCardsForSponsor(StageModel[] cardsPlayed)
    {
        foreach(StageModel stage in cardsPlayed)
        {
            Cmd_sponsorStage(stage.getIndexList().ToArray());
            foreach(int index in stage.getIndexList())
            {
                Cmd_removeCard(index);
            }
            
        }
    }

    [Command] void Cmd_sponsorStage(int[] stage)
    {
        NetSponsorModel.instance.AddStage(stage);
    } 

    // ------------ DESTRUCTION --------------------

    #region Destruction
    private void OnDestroy()
    {
        GameManager.players.Remove(this);
        if(isLocalPlayer)
            _view.destroyView();
    }
    #endregion
}
