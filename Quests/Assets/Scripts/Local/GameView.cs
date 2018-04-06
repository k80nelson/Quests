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
        statsList.Add(stats);
        setNames();
        pollStats();
        RpcFindStats();
    }

    void setNames()
    {
        if (!isServer) return;
        foreach(PlayerStatsView stats in statsList)
        {
            stats.playerstr = "P" + (stats.index + 1);
        }
    }

    public void pollStats()
    {
        if (!isServer) return;
        foreach(PlayerStatsView stats in statsList)
        {
            stats.rankstr = "Rank: " + GameController.instance.players[stats.index].model.rank.ToString();
            stats.shieldstr = "Shields: " + GameController.instance.players[stats.index].model.shields;
            stats.cardsstr = "Cards: " + GameController.instance.players[stats.index].model.hand.Count;
        }
    }

    [ClientRpc]
    void RpcFindStats()
    {
        GameObject[] stats = GameObject.FindGameObjectsWithTag("PlayerStats");
        foreach (GameObject stat in stats)
        {
            stat.transform.SetParent(statsTransform);
        }
    }



}
