using UnityEngine;
using UnityEngine.Networking;

public class GameNetworkManager : NetworkManager
{
    public int numActivePlayers = 0;

    private void Awake()
    {
        Network.logLevel = NetworkLogLevel.Full;
    }
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        numActivePlayers += 1;
        GameObject player = (GameObject)Instantiate(playerPrefab,GameController.instance.transform);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
