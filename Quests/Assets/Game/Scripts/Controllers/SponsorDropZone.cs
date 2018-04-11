using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponsorDropZone : DropZone {

    SponsorController ctrl;

    private void Awake()
    {
        ctrl = GetComponentInParent<SponsorController>();
    }

    protected override bool isValid(Draggable d)
    {
        List<AdventureCard> children = new List<AdventureCard>();
        foreach(Card child in CardContainer.GetComponentsInChildren<Card>())
        {
            children.Add(child.card as AdventureCard);
        }

        return ctrl.testValid(d.GetComponent<Card>().card as AdventureCard, children);
    }
}
