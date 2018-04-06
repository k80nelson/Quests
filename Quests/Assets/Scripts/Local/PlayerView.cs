using UnityEngine;

public class PlayerView : MonoBehaviour{

    public GameObject cardArea;
    public Transform cardSpawnPoint;

    public GameObject cardContainerPrefab;

    public GameObject advCardPrefab;
    

    public void makeCardArea()
    {
        Debug.Log("Making Card Area for player");
        cardArea = Instantiate(cardContainerPrefab, GameController.instance.transform);
        cardSpawnPoint = cardArea.GetComponent<DropZone>().CardContainer;
    }

    public void createCard(AdventureCard card)
    {
        Card newCard = Instantiate(advCardPrefab, cardSpawnPoint).GetComponent<Card>();
        newCard.setCard(card);
    }
}
