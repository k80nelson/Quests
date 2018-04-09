using UnityEngine;

public class PlayerView : MonoBehaviour{
    
    [SerializeField] GameObject cardContainerPrefab;
    [SerializeField] GameObject advCardPrefab;

    GameObject cardArea;
    Transform cardSpawnPoint;

    public void makeCardArea()
    {
        cardArea = Instantiate(cardContainerPrefab, GameController.instance.transform);
        cardSpawnPoint = cardArea.GetComponent<DropZone>().CardContainer;
    }

    public void createCard(AdventureCard card)
    {
        Card newCard = Instantiate(advCardPrefab, cardSpawnPoint).GetComponent<Card>();
        newCard.setCard(card);
        newCard.name = card.name;
    }

    public void destroyCard(GameObject card)
    {
        Destroy(card);
    }
    
}
