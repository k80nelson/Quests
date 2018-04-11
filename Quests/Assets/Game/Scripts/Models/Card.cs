using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Image image;
    public BaseCard card;

    // Called in the client
    public void setCard(BaseCard card)
    {
        this.card = card;
        updateImage();
    }

    public void applyCard()
    {
        // Should only be called from one client
        if (card is StoryCard)
        {
            ((StoryCard)card).Apply();
        }
    }

    void updateImage()
    {
        if (card != null)
        {
            image.sprite = card.image;
        }
    }
}
