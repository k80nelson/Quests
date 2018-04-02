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
        if (numPlayers == 1) highestBid = 2;
        else highestBid = minBid - 1;
    }
    
}
