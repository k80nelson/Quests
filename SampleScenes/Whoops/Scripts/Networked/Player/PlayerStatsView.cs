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

    [SyncVar]
    public string rankstr = "Rank: ";
    [SyncVar]
    string shieldstr = "Shields: ";
    [SyncVar]
    string cardsstr = "Cards: ";
    [SyncVar]
    public string playerstr;
    [SyncVar]
    public int index;
    
    public void setPlayerText(int playerNum)
    {
        if (!isServer) return;
        playerstr = "P" + playerNum;
        Rpc_PlayerUI();
    }

    public void setValues(string rank, int shields, int cards)
    {
        if (!isServer) return;
        rankstr = "Rank: " + rank;
        shieldstr = "Shields: " + shields;
        cardsstr = "Cards: " + cards;
        Rpc_ValueUI();
    }

    public void setRank(string rank)
    {
        if (!isServer) return;
        rankstr = "Rank: " + rank;
        Rpc_RankUI();
    }

    public void setShield(int shields)
    {
        if (!isServer) return;
        shieldstr = "Shields: " + shields;
        Rpc_ShieldUI();
    }

    public void setCards(int cards)
    {
        if (!isServer) return;
        cardsstr = "Cards: " + cards;
        Rpc_CardUI();
    }

    [ClientRpc]
    public void Rpc_ValueUI()
    {
        RankObj.text = rankstr;
        ShieldObj.text = shieldstr;
        CardsObj.text = cardsstr;
    }

    [ClientRpc]
    void Rpc_RankUI()
    {
        RankObj.text = rankstr;
    }

    [ClientRpc]
    public void Rpc_PlayerUI()
    {
        PlayerObj.text = playerstr;
    }

    [ClientRpc]
    void Rpc_ShieldUI()
    {
        ShieldObj.text = shieldstr;
    }

    [ClientRpc]
    void Rpc_CardUI()
    {
        CardsObj.text = cardsstr;
    }
}
