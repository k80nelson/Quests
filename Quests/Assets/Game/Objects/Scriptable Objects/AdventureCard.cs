using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAdventureCard", menuName ="Adventure Card")]
public class AdventureCard : BaseCard {

    public int BP = 0;
    public int Bids = 0;
    public int SpecialBP = 0;
    public int SpecialBids = 0;
    public int MinBid = 0;
    public int specialMinBid = 0;
    public List<BaseCard> SpecialCards;
    public AdventureCardType type;

    public int getBP()
    {
        return BP;
    }

    public int getBids()
    {
        return Bids;
    }

    public int getMinimumBid()
    {
        return MinBid;
    }

}



public enum AdventureCardType { ALLY, FOE, WEAPON, TEST, AMOUR };
