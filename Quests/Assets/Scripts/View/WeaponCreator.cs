using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCreator : CreatorBase<QuestOTRT.Weapon>
{

    public override void create(QuestOTRT.Weapon card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
