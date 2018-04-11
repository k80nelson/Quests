using UnityEngine;
using UnityEngine.UI;

public enum PlayType { SPONSOR, QUEST, TOURNAMENT }

public class JoinController : MonoBehaviour {

    // ---- ATTRIBUTES ----
    [SerializeField] Button yesBtn;
    [SerializeField] Button noBtn;
    [SerializeField] Text promptText;
    [SerializeField] Image card;
    [SerializeField] GameObject hierarchy;

    PlayType joinType;

    // ---- INITIALIZATION ----

    public void Init(PlayType type, Sprite sprite)
    {
        joinType = type;
        switch (joinType)
        {
            case (PlayType.SPONSOR):
                promptText.text = "Would you like to sponsor this quest?";
                break;
            case (PlayType.QUEST):
                promptText.text = "Would you like to join this quest?";
                break;
            case (PlayType.TOURNAMENT):
                promptText.text = "Would you like to join this tournament?";
                break;
            default: return;
        }

        card.sprite = sprite;
        hierarchy.SetActive(true);
    }
    
    // ---- BUTTON FUNCTIONS ----

    public void yes()
    {
        switch (joinType)
        {
            case (PlayType.SPONSOR): sponsorYes();
                break;
            case (PlayType.QUEST): questYes();
                break;
            case (PlayType.TOURNAMENT): tourYes();
                break;
            default: return;
        }
        hierarchy.SetActive(false);
    }

    void sponsorYes()
    {
        SponsorHandler.instance.SendServerAcceptSponsor();
    }

    void questYes()
    {
        NetPlayerController.LocalPlayer.drawAdvCards(1);
        SponsorHandler.instance.SendServerAcceptQuest(NetPlayerController.LocalPlayer.index);
    }

    void tourYes()
    {
        TourHandler.instance.SendServerAcceptTour(NetPlayerController.LocalPlayer.index);
    }

    public void no()
    {
        switch (joinType)
        {
            case (PlayType.SPONSOR):
                sponsorNo();
                break;
            case (PlayType.QUEST):
                questNo();
                break;
            case (PlayType.TOURNAMENT):
                tourNo();
                break;
            default: return;
        }
        hierarchy.SetActive(false);
    }

    void sponsorNo()
    {
        SponsorHandler.instance.SendServerRefuseSponsor();
    }

    void questNo()
    {
        SponsorHandler.instance.SendServerRefuseQuest(NetPlayerController.LocalPlayer.index);
    }

    void tourNo()
    {
        TourHandler.instance.SendServerRefuseTour(NetPlayerController.LocalPlayer.index);
    }
}
