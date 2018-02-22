using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour {

    public void create(QuestOTRT.AdventureCard card)
    {
        if (card is QuestOTRT.Ally) GetComponent<AllyCreator>().create(card as QuestOTRT.Ally);
        if (card is QuestOTRT.Amour) GetComponent<AmourCreator>().create(card as QuestOTRT.Amour);
        if (card is QuestOTRT.Foe) GetComponent<FoeCreator>().create(card as QuestOTRT.Foe);
        if (card is QuestOTRT.Test) GetComponent<TestCreator>().create(card as QuestOTRT.Test);
        if (card is QuestOTRT.Weapon) GetComponent<WeaponCreator>().create(card as QuestOTRT.Weapon);
    }

    public void create(QuestOTRT.StoryCard card)
    {
        if (card is QuestOTRT.Quest) GetComponent<QuestCreator>().create(card as QuestOTRT.Quest);
        if (card is QuestOTRT.Tournament) GetComponent<TournamentCreator>().create(card as QuestOTRT.Tournament);
        if (card is QuestOTRT.Event) GetComponent<EventCreator>().create(card as QuestOTRT.Event);
    }


}
