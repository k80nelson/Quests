using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestCard", menuName = "Quest Card")]
class QuestCard : StoryCard
{
    public int stages = 0;

    public override void Apply()
    {
        SponsorHandler.instance.SendServerSponsorStartMsg(index);
    }
}

