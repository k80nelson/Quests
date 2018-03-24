using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuestDropZone : DropZone {

    public Sponsor sponsorship;
    public int id;
    private bool valid = false;


	protected override bool isValid(Draggable d)
    {
        return sponsorship.testValid(id, d);
    }

    
}
