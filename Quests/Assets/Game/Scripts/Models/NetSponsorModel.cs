using UnityEngine;
using UnityEngine.Networking;

public class NetSponsorModel : NetworkBehaviour {

    #region Singleton
    public static NetSponsorModel instance;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    public struct StageStruct
    {
        public int[] Stage;
        public StageStruct(int[] stage)
        {
            Stage = stage;
        }
    };

    public class SyncListStage : SyncListStruct<StageStruct> { }

    public SyncListStage SponsorStages = new SyncListStage();

    [Server] public void AddStage(int[] stage)
    {
        StageStruct newStage = new StageStruct(stage);
        SponsorStages.Add(newStage);
    }

    [Server] public void ClearStages()
    {
        SponsorStages.Clear();
    }

    public int[] GetStage(int index)
    {
        StageStruct ret = SponsorStages[index];
        return ret.Stage;
    }
}
