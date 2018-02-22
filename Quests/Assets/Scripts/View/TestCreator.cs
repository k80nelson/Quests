using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCreator : CreatorBase<QuestOTRT.Test>
{ 

    public override void create(QuestOTRT.Test card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
