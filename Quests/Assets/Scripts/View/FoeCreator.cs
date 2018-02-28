using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCreator : CreatorBase<QuestOTRT.Foe>
{
    protected override void initCard(GameObject obj, QuestOTRT.Foe card)
    {
        obj.GetComponent<QuestOTRT.FoeController>().initialize(card);
    }
}
