using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDropZone : DropZone {

    public CombatController quest;
 
    protected override bool isValid(Draggable d)
    {
        return quest.validate(d.GetComponent<AdventureCard>());
    }
}
