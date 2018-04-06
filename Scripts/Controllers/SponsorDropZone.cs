using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SponsorDropZone : DropZone {

    public Sponsor sponsorship;
    public int id;


	protected override bool isValid(Draggable d)
    {
        return sponsorship.testValid(id, d);
    }
    
}
