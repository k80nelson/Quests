using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lobby;
using UnityEngine.Networking;


public class GameLobbyHook : LobbyHook {


    // Called before GameScene is fully loaded but after all players are ready
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        NetPlayerController player = gamePlayer.GetComponent<NetPlayerController>();

        player.playerName = lobby.playerName;
    }
}
