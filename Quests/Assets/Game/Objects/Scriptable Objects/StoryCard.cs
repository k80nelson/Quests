using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StoryCard : BaseCard {

    public virtual void Apply()
    {
        Debug.Log("Applying card " + name);
    }
}

