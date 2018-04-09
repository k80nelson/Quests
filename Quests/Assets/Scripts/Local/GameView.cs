using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameView : NetworkBehaviour {

    public GameObject StatsPrefab;
    public Transform statsTransform;

    public List<PlayerStatsView> statsList = new List<PlayerStatsView>();

    public void makeStat()
    {
        if (!isServer) return;
        PlayerStatsView stats = Instantiate(StatsPrefab, statsTransform).GetComponent<PlayerStatsView>();
        NetworkServer.Spawn(stats.gameObject);
        stats.index = statsList.Count;
        pollStat(stats);
        statsList.Add(stats);
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

    public void pollStat(PlayerStatsView stat)
    {
        if (!isServer) return;
        stat.setValues(
            GameController.instance.players[stat.index].model.rank.ToString(),
            GameController.instance.players[stat.index].model.shields,
            GameController.instance.players[stat.index].model.hand.Count);
        stat.setPlayerText(stat.index + 1);
    }

    public void pollStats()
    {
        if (!isServer) return;
        foreach(PlayerStatsView stats in statsList)
        {
            stats.setRank(GameController.instance.players[stats.index].model.rank.ToString());
            stats.setShield(GameController.instance.players[stats.index].model.shields);
            stats.setCards(GameController.instance.players[stats.index].model.hand.Count);
        }
    }

    [Command]
    void Cmd_FindStats()
    {
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
        Cmd_FindStats();
    }



}
