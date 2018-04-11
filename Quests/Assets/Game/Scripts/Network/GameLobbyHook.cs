using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lobby;
using UnityEngine.Networking;


public class GameLobbyHook : LobbyHook {


    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        // Called before GameScene is fully loaded but after all players are ready
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        NetPlayerController player = gamePlayer.GetComponent<NetPlayerController>();

        player.playerName = lobby.playerName;
    }
}
