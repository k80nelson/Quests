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

    [SyncVar(hook = "OnNameChanged")]
    public string playerName;

    [SyncVar]
    public int bp = 5;

    public Hand hand = ScriptableObject.CreateInstance<Hand>();

    private void Awake()
    {
        _view = GetComponent<PlayerView>();
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

    void OnNameChanged(string newVal)
    {
        playerName = newVal;
        _view.updatePlayerText(newVal);
    }
}
