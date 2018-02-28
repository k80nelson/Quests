using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourCreator : CreatorBase<QuestOTRT.Amour>
{
    protected override void initCard(GameObject obj, QuestOTRT.Amour card)
    {
        obj.GetComponent<QuestOTRT.AmourController>().initialize(card);
    }

}
