using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum Rank { Squire, Knight, Champion };
public class NetPlayerModel : NetworkBehaviour {

    protected PlayerView _view;
    
    [SyncVar(hook = "OnRankChanged")]
    public int rankInt = 0;

    [SyncVar(hook = "OnShieldsChanged")]
    public int shields = 0;

    [SyncVar(hook = "OnCardsChanged")]
    public int cards = 0;

    public const int maxCards = 12;

    [SyncVar]
    public int bp = 5;

    Hand _hand;

    private void Awake()
    {
        _view = GetComponent<PlayerView>();
    }

    [Server]
    public void AddCard(AdventureCard card)
    {
        if (_hand == null) _hand = ScriptableObject.CreateInstance<Hand>();
        _hand.Add(card);
        cards += 1;
    }

    [Server]
    public void removeCard(AdventureCard card)
    {
        _hand.remove(card);
        cards -= 1;
    }

    [Server]
    public void Init()
    {
        rankInt = 0;
        shields = 0;
        cards = 0;
        bp = 5;
    }

    // -- SyncVar hooks
    void OnRankChanged(int newVal)
    {
        rankInt = newVal;
        _view.updateRankText(newVal);
    }

    void OnShieldsChanged(int newVal)
    {
        shields = newVal;
        _view.updateShieldText(newVal);
    }

    void OnCardsChanged(int newVal)
    {
        cards = newVal;
        _view.updateCardText(newVal);
    }

}
