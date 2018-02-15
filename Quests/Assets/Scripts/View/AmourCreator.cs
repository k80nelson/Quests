using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourCreator : CreatorBase<QuestOTRT.Amour>
{
    
    public override void create(QuestOTRT.Amour card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
