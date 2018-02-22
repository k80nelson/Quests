using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TournamentCreator : CreatorBase<QuestOTRT.Tournament>
{

    public override void create(QuestOTRT.Tournament card)
    {
        Sprite display = sprites[0];
        GameObject newcard = Instantiate(prefab);
        SpriteRenderer sr = newcard.GetComponent<SpriteRenderer>();
        sr.sprite = display;
    }
}
