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
        Debug.Log("[JoinController.cs:Init] Initializing join prompt for " + type.ToString());
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
        Debug.Log("[JoinController.cs:sponsorYes] " + NetPlayerController.LocalPlayer.name + " accepts sponsorship.");
        SponsorHandler.instance.SendServerAcceptSponsor();
    }

    void questYes()
    {
        Debug.Log("[JoinController.cs:questYes] " + NetPlayerController.LocalPlayer.name + " accepts quest.");
        NetPlayerController.LocalPlayer.drawAdvCards(1);
        SponsorHandler.instance.SendServerAcceptQuest(NetPlayerController.LocalPlayer.index);
    }

    void tourYes()
    {
        Debug.Log("[JoinController.cs:tourYes] " + NetPlayerController.LocalPlayer.name + " accepts tounament.");
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
        Debug.Log("[JoinController.cs:Sponsorno] " + NetPlayerController.LocalPlayer.name + " declines sponsorship.");
        SponsorHandler.instance.SendServerRefuseSponsor();
    }

    void questNo()
    {
        Debug.Log("[JoinController.cs:questno] " + NetPlayerController.LocalPlayer.name + " declines quest.");
        SponsorHandler.instance.SendServerRefuseQuest(NetPlayerController.LocalPlayer.index);
    }

    void tourNo()
    {
        Debug.Log("[JoinController.cs:Tourno] " + NetPlayerController.LocalPlayer.name + " declines tournament.");
        TourHandler.instance.SendServerRefuseTour(NetPlayerController.LocalPlayer.index);
    }
}
