using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropZone : DropZone {

    [SerializeField] QuestController ctrl;

    protected override bool isValid(Draggable d)
    {
        return ctrl.valid(d.GetComponent<Card>().card as AdventureCard);
    }
}
