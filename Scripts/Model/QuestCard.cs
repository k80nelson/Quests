using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCard : StoryCard
{
    public int stages;
    public override void Apply()
    {
        GameObject.FindGameObjectWithTag("ActiveArea").GetComponent<Gameplay>().StartSponsor();
    }
}
