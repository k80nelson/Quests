using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourDropZone : DropZone {

    public TournamentController tour;

    protected override bool isValid(Draggable d)
    {
        return tour.validate(d.GetComponent<AdventureCard>());
    }
}
