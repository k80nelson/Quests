using UnityEngine;
using UnityEngine.Networking;

public class PlayerView : NetworkBehaviour{

    void Start()
    {
        gameObject.transform.SetParent(GameController.instance.transform);
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(0, 200);
        gameObject.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        showCardArea();
    }

    [Client]
    void showCardArea()
    {
        if (!isLocalPlayer) return;
        DropZone cardArea = transform.GetComponentInChildren<DropZone>();
        cardArea.transform.localPosition = new Vector3(0, 0, 0);
        cardArea.transform.localScale = new Vector3(1, 1, 1);
    }
    
}
