using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GameView : NetworkBehaviour {

    // Player Stats things
    [SerializeField] GameObject StatsPrefab;
    [SerializeField] Transform statsTransform;
    List<PlayerStatsView> statsList = new List<PlayerStatsView>();


    // -- PLAYER STATS -- //
    public void makeStat(GPlayerController player)
    {
        if (!isServer) return;
        PlayerStatsView stats = Instantiate(StatsPrefab, statsTransform).GetComponent<PlayerStatsView>();
        NetworkServer.Spawn(stats.gameObject);
        stats.index = statsList.Count;
        pollStat(stats, player);
        statsList.Add(stats);
        FindStats();
        Rpc_FindStats();
    }

    void setNames()
    {
        if (!isServer) return;
        foreach(PlayerStatsView stats in statsList)
        {
            stats.setPlayerText(stats.index+1);
        }
    }

    public void pollStat(PlayerStatsView stat, GPlayerController player)
    {
        if (!isServer) return;
        stat.setValues(
            player.model.rank.ToString(),
            player.model.shields,
            player.model.hand.Count);
        stat.setPlayerText(stat.index + 1);
    }

    public void pollStats()
    {
        if (!isServer) return;
        foreach(PlayerStatsView stats in statsList)
        {
            stats.setRank(GameModel.instance.getPlayer(stats.index).model.rank.ToString());
            stats.setShield(GameModel.instance.getPlayer(stats.index).model.shields);
            stats.setCards(GameModel.instance.getPlayer(stats.index).model.hand.Count);
        }
    }

    public void FindStats()
    {
        if (!isServer) return;
        foreach (PlayerStatsView stats in statsList)
        {
            stats.Rpc_PlayerUI();
            stats.Rpc_ValueUI();
        }
    }

    [ClientRpc]
    void Rpc_FindStats()
    {
        GameObject[] stats = GameObject.FindGameObjectsWithTag("PlayerStats");
        foreach (GameObject stat in stats)
        {
            stat.transform.SetParent(statsTransform);
        }
    }

}
