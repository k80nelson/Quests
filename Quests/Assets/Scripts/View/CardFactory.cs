using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour {

    public GameObject create(QuestOTRT.AdventureCard card)
    {
        if (card is QuestOTRT.Ally) return GetComponent<AllyCreator>().create(card as QuestOTRT.Ally);
        if (card is QuestOTRT.Amour) return GetComponent<AmourCreator>().create(card as QuestOTRT.Amour);
        if (card is QuestOTRT.Foe) return GetComponent<FoeCreator>().create(card as QuestOTRT.Foe);
        if (card is QuestOTRT.Test) return GetComponent<TestCreator>().create(card as QuestOTRT.Test);
        if (card is QuestOTRT.Weapon) return GetComponent<WeaponCreator>().create(card as QuestOTRT.Weapon);
        return null;
    }

    public GameObject create(QuestOTRT.StoryCard card)
    {
        if (card is QuestOTRT.Quest) return GetComponent<QuestCreator>().create(card as QuestOTRT.Quest);
        if (card is QuestOTRT.Tournament) return GetComponent<TournamentCreator>().create(card as QuestOTRT.Tournament);
        if (card is QuestOTRT.Event) return GetComponent<EventCreator>().create(card as QuestOTRT.Event);
        return null;
    }

}
