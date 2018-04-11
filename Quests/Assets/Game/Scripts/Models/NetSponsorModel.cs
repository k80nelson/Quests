using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class NetSponsorModel : NetworkBehaviour {

    #region Singleton
    public static NetSponsorModel instance;
    #endregion

    #region Types
    public struct StageStruct
    {
        public int[] Stage;
        public StageStruct(int[] stage)
        {
            Stage = stage;
        }
    };

    public class SyncListStage : SyncListStruct<StageStruct> { }
    #endregion

    public SyncListStage SponsorStages = new SyncListStage();
    [SyncVar] public int numCards = 0;
    
    private void Awake()
    {
        instance = this;
    }

    public StageModel getStage(int index)
    {
        int[] stage = GetStage(index);
        return new StageModel(stage);
    }

    [Server] public void AddStage(int[] stage)
    {
        numCards += stage.Length;
        StageStruct newStage = new StageStruct(stage);
        SponsorStages.Add(newStage);
    }

    [Server] public void ClearStages()
    {
        numCards = 0;
        SponsorStages.Clear();
    }

    public int[] GetStage(int index)
    {
        StageStruct ret = SponsorStages[index];
        return ret.Stage;
    }
}
