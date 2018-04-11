using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewTournamentCard", menuName = "Tournament Card")]
class TournamentCard : StoryCard
{
    public int shields = 0;

    public override void Apply()
    {
        TourHandler.instance.SendServerTourStartMsg(index);
    }
}