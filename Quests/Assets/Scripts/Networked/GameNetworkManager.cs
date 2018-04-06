using UnityEngine;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager
{
    private void Awake()
    {
        Network.logLevel = NetworkLogLevel.Full;
    }
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        GameObject player = (GameObject)Instantiate(playerPrefab,GameController.instance.transform);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
