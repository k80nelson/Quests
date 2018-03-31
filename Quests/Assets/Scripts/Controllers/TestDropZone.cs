using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDropZone : DropZone
{

    public Quest quest;

    protected override bool isValid(Draggable d)
    {
        return quest.biddingValidity(d.GetComponent<AdventureCard>());
    }
}
