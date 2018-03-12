using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureCard : BaseCard {
    public enum Type { ALLY, FOE, WEAPON, TEST, AMOUR }

    public Type type;
    public int BP;
    public int Bids;
    public int SpecialBP;
    public int SpecialBids;
    public BaseCard[] SpecialCards;
}
