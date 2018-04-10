using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    [SerializeField] Image image;
    public BaseCard card;

    /* call this from the client */
    public void setCard(BaseCard card)
    {
        this.card = card;
        updateImage();
    }

    void updateImage()
    {
        if (card != null)
        {
            image.sprite = card.image;
        }
    }
}
