using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentCreator : CreatorBase<QuestOTRT.Tournament>
{
    protected override void initCard(GameObject obj, QuestOTRT.Tournament card)
    {
        obj.GetComponent<QuestOTRT.TournamentController>().initialize(card);
    }
}
