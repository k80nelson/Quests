using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreator : CreatorBase<QuestOTRT.Test>
{
    protected override void initCard(GameObject obj, QuestOTRT.Test card)
    {
        obj.GetComponent<QuestOTRT.TestController>().initialize(card);
    }
}
