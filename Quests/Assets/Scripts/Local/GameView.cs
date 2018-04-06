using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameView : NetworkBehaviour {

    public GameObject playerStatsPrefab;
    public Transform playerStatsContainer;

    public List<PlayerStatsView> playerStats;

    [Server]
    public void CreatePlayerStats(PlayerController player)
    {
        GameObject stats = Instantiate(playerStatsPrefab, playerStatsContainer);
        stats.GetComponent<PlayerStatsView>().addPlayer(player);
        playerStats.Add(stats.GetComponent<PlayerStatsView>());
        stats.GetComponent<PlayerStatsView>().setPlayerText(player.model.index);
        NetworkServer.Spawn(stats);
        RpcAddStats();
    }

    [ClientRpc]
    public void RpcAddStats()
    {
        GameObject[] stats = GameObject.FindGameObjectsWithTag("PlayerStats");
        foreach (GameObject stat in stats)
        {
            stat.transform.SetParent(playerStatsContainer);
        }
    }

    [Server] 
    public void updateStats()
    {
        Debug.Log("Updating stats");

        foreach(PlayerStatsView stat in playerStats)
        {
            stat.updateValues();
        }
    }
}
