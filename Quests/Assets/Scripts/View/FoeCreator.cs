using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeCreator : CreatorBase<QuestOTRT.Foe>
{

    public override void create(QuestOTRT.Foe card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
