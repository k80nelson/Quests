using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropZone : DropZone {

    public Quest quest;
 
    protected override bool isValid(Draggable d)
    {
        return quest.validateCard(d.GetComponent<AdventureCard>());
    }
}
