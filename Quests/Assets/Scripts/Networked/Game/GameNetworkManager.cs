using UnityEngine;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager
{
    // used to initialize anything the SERVER NEEDS WHEN A PLAYER JOINS -> ALSO TO INITIALIZE PLAYER VALUES
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("Player is Joining on the Server");
        GameObject player = (GameObject)Instantiate(playerPrefab,GameController.instance.transform);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
        GameController.instance.makePlayer(player.GetComponent<PlayerController>());
        player.GetComponent<PlayerController>().drawAdvCards(12);
    }
}
