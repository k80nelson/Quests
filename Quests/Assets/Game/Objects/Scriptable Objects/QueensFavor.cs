using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lowest ranked player(s) immediately recieve 2 Adventure Cards
[CreateAssetMenu(menuName = "QueensFav")]
public class QueensFavor : EventCard
{
    
    public override void Apply()
    {
        //throw new System.NotImplementedException();
        List<NetPlayerController> players = GameManager.players;

        int curLowestRank = 0; // 0 = squire (lowest player)
        int size = 0;
        int i = 0;
        while(i < players.Count)
            {
                if(players[i].getRank() <= curLowestRank)
                {
                    players[i].drawAdvCards(2);
                    size++;
                }

                if(i == players.Count - 1 && size == 0)
                {
                    curLowestRank++;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

        Debug.Log("[QueensFavor:play] Queen's Favor complete -> lowest ranked players add 2 adventure cards");
    }
}
