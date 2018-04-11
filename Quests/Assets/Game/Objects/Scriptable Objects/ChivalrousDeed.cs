using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Chivalrous")]
//obj: Player(s) with lowest rank and least amount of shields gains 3 shields
public class ChivalrousDeed : EventCard {

    public override void Apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;
    }

}
