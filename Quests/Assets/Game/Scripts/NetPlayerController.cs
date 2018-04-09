using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetPlayerModel))]
[RequireComponent(typeof(PlayerView))]
public class NetPlayerController : NetworkBehaviour {

    protected PlayerView _view;
    protected NetPlayerModel _model;

    protected bool _wasInit;

    private void Awake()
    {
        GameManager.players.Add(this);
    }

    private void Start()
    {
        _view = GetComponent<PlayerView>();
        _model = GetComponent<NetPlayerModel>();
        
        _model.enabled = isServer;
        if (GameManager.instance != null)
        {
            Init();
        }
    }

    private void OnDestroy()
    {
        GameManager.players.Remove(this);
    }

    public void Init()
    {
        if (_wasInit) return;
        _view.initStats(isLocalPlayer);
        _model.playerName = this.name;
        _model.rankInt = 0;
        _model.shields = 0;
        _model.cards = 0;
        _model.bp = 5;
        if (isLocalPlayer) _view.initLocal();
        _wasInit = true;
    }
}
