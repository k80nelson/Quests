using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator : CreatorBase<QuestOTRT.Event>
{
    protected override void initCard(GameObject obj, QuestOTRT.Event card)
    {
        obj.GetComponent<QuestOTRT.EventController>().initialize(card);
    }
}
