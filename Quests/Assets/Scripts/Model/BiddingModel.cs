using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiddingModel : GameElement
{
    public int highestBid;
    public int highestPlayer;

    public void initialize(int numPlayers, int minBid)
    {
        highestPlayer = -1;
        highestBid = (numPlayers == 1) ? 2 : minBid;
    }
    
}
