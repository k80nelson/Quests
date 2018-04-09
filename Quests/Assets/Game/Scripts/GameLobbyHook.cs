using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lobby;
using UnityEngine.Networking;

public class GameLobbyHook : LobbyHook {

    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
        NetPlayerController player = gamePlayer.GetComponent<NetPlayerController>();

        player.name = lobby.playerName;
        
    }
}
