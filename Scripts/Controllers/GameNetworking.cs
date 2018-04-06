using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameNetworking : NetworkManager {

	public override void OnServerAddPlayer(NetworkConnection conn,short playerControllerId)
    {
        GameObject player = Gameplay.instance.makePlayer();
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
