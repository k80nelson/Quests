using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatModel : GameElement {

    public int counter = 0;

    public bool hasEnded(int numPlayers)
    {
        return (counter == numPlayers);
    }
}
