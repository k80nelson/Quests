using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourDropZone : DropZone {

    [SerializeField] TournamentController ctrl;

    protected override bool isValid(Draggable d)
    {
        return ctrl.isValid(d.GetComponent<Card>().card as AdventureCard);
    }
}
