using UnityEngine;

public class PlayerView : MonoBehaviour{

    
    GameObject cardArea;
    Transform cardSpawnPoint;

    [SerializeField]
    GameObject cardContainerPrefab;


    [SerializeField]
    GameObject advCardPrefab;
    

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
        newCard.name = card.name;
    }

    public void destroyCard(GameObject card)
    {
        Destroy(card);
    }
    
}
