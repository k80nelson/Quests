﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureCard : BaseCard {

    public enum Type { ALLY, FOE, WEAPON, TEST, AMOUR }

    public Type type;
    public int BP;
    public int Bids;
    public int SpecialBP;
    public int SpecialBids;
    public int MinBid;
    public int specialMinBid;
    public List<string> SpecialCards;

    public int getBP()
    {
        if (SpecialCards == null) return BP;
        
        GameObject stryCard = GameObject.FindGameObjectWithTag("CurrStory");
        if (stryCard != null)
        {
            if (SpecialCards.Contains(stryCard.name))
            {
                return SpecialBP;
            }
        }

        return BP;
    }

    public int getBids()
    {
        return Bids;
    }

    public int getMinimumBid()
    {
        if (SpecialCards == null) return MinBid;

        GameObject stryCard = GameObject.FindGameObjectWithTag("CurrStory");
        if (stryCard != null)
        {
            if (SpecialCards.Contains(stryCard.name))
            {
                return specialMinBid;
            }
        }

        return MinBid;
    }
}
