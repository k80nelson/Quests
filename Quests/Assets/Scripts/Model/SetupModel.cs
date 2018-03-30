using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupModel
{

    public List<StageModel> stageSetup;

    //Constructor to create the setup for the stage
    public SetupModel()
    {
        stageSetup = new List<StageModel>();
    }

    public SetupModel(SetupModel model)
    {
        stageSetup = new List<StageModel>(model.stageSetup);
    }

    //Returns the number of players involved in that quest
    //if it is 1, then there are no players and only the sponsor in the quest, meaning quest is over.
    public int Count
    {
        get
        {
            return stageSetup.Count;
        }
    }

    //Ability to add one players cards to the list, used for the players on the quest
    public void Add(StageModel stage)
    {
        if (stageSetup == null) stageSetup = new List<StageModel>();
        stageSetup.Add(stage);
    }

    //Ability to add a list of stages to the list, used for the sponsor for the quest
    public void addList(List<StageModel> stages)
    {
        if (stageSetup == null) stageSetup = new List<StageModel>();
        this.stageSetup.AddRange(stages);
    }

    public StageModel getStage(int index)
    {
        return stageSetup[index];
    }

    //Remove one stage from the list, this can be used to remove one player from the list of stages if they lose a quest
    public void Remove(StageModel stage)
    {
        if (stageSetup == null) return;
        stageSetup.Remove(stage);
    }

    public void Empty()
    {
        stageSetup.Clear();
    }
}
