using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Lobby;

public class GameManager : NetworkBehaviour {

	static public List<NetPlayerController> players = new List<NetPlayerController>();
    static public GameManager instance = null;

    public Transform statsUIZone;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (isServer)
        {

        }
        for (int i=0; i<players.Count; i++)
        {
            players[i].Init();
        }
    }

    public Transform getActiveArea()
    {
        return this.transform;
    }
}
