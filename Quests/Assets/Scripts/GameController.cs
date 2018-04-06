using UnityEngine;

public class GameController : MonoBehaviour {

    #region Singleton
    public static GameController instance;
    #endregion

    public Transform activeArea;

    public void Start()
    {
        instance = this;
        this.activeArea = this.transform;
    }
}
