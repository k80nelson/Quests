using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCreator : CreatorBase<QuestOTRT.Event>
{

    public override void create(QuestOTRT.Event card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
