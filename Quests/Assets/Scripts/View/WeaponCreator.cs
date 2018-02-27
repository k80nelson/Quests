using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreator : CreatorBase<QuestOTRT.Weapon>
{
    protected override void initCard(GameObject obj, QuestOTRT.Weapon card)
    {
        obj.GetComponent<QuestOTRT.WeaponController>().initialize(card);
    }
}
