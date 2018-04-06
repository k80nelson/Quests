using UnityEngine;
using UnityEngine.Networking;

public class PlayerModel : NetworkBehaviour
{
    public PlayerRank rank = PlayerRank.Squire;
    public Hand hand;
    [SyncVar]
    public bool registered = false;
    [SyncVar]
    public int index = -1;
    [SyncVar]
    public int shields = 0;
    [SyncVar]
    public int bp = 5;

    public void Awake()
    {
        hand = ScriptableObject.CreateInstance<Hand>();
    }
    
}

public enum PlayerRank { Squire, Knight, Champion, RoundTable };