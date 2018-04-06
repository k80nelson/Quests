using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDropZone : DropZone
{
    public BiddingController quest;

    protected override bool isValid(Draggable d)
    {
        return quest.validate();
    }
}
