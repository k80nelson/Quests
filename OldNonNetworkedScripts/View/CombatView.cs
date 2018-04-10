using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatView : GameElement
{
    public Text stageText;

    public void setEncounterText(int stage)
    {
        stageText.text = "Stage " + stage;
    }
}
