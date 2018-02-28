using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCreator : CreatorBase<QuestOTRT.Quest>
{
    protected override void initCard(GameObject obj, QuestOTRT.Quest card)
    {
        obj.GetComponent<QuestOTRT.QuestController>().initialize(card);
    }
}
