using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS IS ONLY TO ME MODIFIED ON THE SERVER
public class GameModel : MonoBehaviour {

    #region Singleton

    public static GameModel instance;

    #endregion

    List<PlayerController> players = new List<PlayerController>();
    int numPlayers = 0;
    public int NumPlayers
    {
        get
        {
            return numPlayers;
        }
    }

    public const int totalPlayers = 2;
    private void Start()
    {
        instance = this;
    }

    public PlayerController getPlayer(int index)
    {
        return players[index];
    }
    
    public void addPlayer(PlayerController player)
    {
        players.Add(player);
        numPlayers += 1;
    }
    
}
