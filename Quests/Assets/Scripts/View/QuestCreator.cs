using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCreator : CreatorBase<QuestOTRT.Quest>
{

    public override void create(QuestOTRT.Quest card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
