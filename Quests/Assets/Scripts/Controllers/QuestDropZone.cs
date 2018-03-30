using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDropZone : DropZone {

    protected override bool isValid(Draggable d)
    {
        return true;
    }
}
