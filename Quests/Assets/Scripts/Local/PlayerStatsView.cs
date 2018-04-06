using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerStatsView : NetworkBehaviour {

    public PlayerController connectedPlayer;

    public Text RankObj;
    public Text ShieldObj;
    public Text CardsObj;
    public Text PlayerObj;

    [SyncVar(hook ="OnRankChange")]
    public string rankstr = "Rank: ";
    [SyncVar(hook = "OnShieldChange")]
    public string shieldstr = "Shields: ";
    [SyncVar(hook = "OnCardChange")]
    public string cardsstr = "Cards: ";
    [SyncVar(hook = "OnPlayerChange")]
    public string playerstr = "P";
    [SyncVar]
    public int index;

    public void setPlayerText(int index)
    {
        if (!isServer) return;
        playerstr = "P" + index;
    }

    public void setValues(string rank, string shield, string cards)
    {
        if (!isServer) return;
        rankstr = rank;
        shieldstr = shield;
        cardsstr = cards;
    }

    public void setRank(string rank)
    {
        if (!isServer) return;
        rankstr = rank;
    }

    public void setShield(string shield)
    {
        if (!isServer) return;
        shieldstr = shield;
    }

    public void setCards(string cards)
    {
        if (!isServer) return;
        cardsstr = cards;
    }

    void OnRankChange(string rank)
    {
        RankObj.text = rank;
    }

    void OnPlayerChange(string player)
    {
        PlayerObj.text = player;
    }

    void OnShieldChange(string shield)
    {
        ShieldObj.text = shield;
    }

    void OnCardChange(string cards)
    {
        CardsObj.text = cards;
    }

   
}
