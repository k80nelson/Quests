using UnityEngine;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager
{
    // used to initialize anything the SERVER NEEDS WHEN A PLAYER JOINS -> ALSO TO INITIALIZE PLAYER VALUES
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("Player is Joining on the Server");
        GameObject player = (GameObject)Instantiate(playerPrefab,GameController.instance.transform);

        // calls PlayerController.OnStartLocalPlayer() for the new player
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        // once completed, calls PlayerController.Start() for each player

        // calls this on the Server
        GameController.instance.makePlayer(player.GetComponent<PlayerController>());
    }
}
