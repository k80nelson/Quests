using UnityEngine;

public class PlayerView : MonoBehaviour{

    public GameObject cardArea;
    public Transform cardSpawnPoint;
    
    public void showCardArea()
    {
        cardArea.SetActive(true);
    }
}
