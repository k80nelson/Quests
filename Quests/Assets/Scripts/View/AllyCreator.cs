using System.Collections;
using System.Collections.Generic;
using QuestOTRT;
using UnityEngine;

public  class AllyCreator : CreatorBase<QuestOTRT.Ally>
{
    protected override void initCard(GameObject obj, Ally card)
    {
        obj.GetComponent<AllyController>().initialize(card);
    }
}
