using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuestOTRT
{
    public class Strategy2 : Strategy
    {
        public Strategy2(PlayerController controller) : base(controller)
        {
        }

        public override void doIParticipationInTournament()
        {
            //participation button is clicked in the back end!
            int currentTotalBP = 0;

            //checks to see if the player bp is already above 50
            if (pc.model.bp >= 50)
                return;
            else  //if not adds the allies to bp to player
            {
                currentTotalBP = pc.model.bp;

                //gets all the players allies
                List<AdventureCard> allies = pc.model.getAllies();
                String[] alliesNames = null;
                
                //loops through all the allies to create a gamestate string[]
                for (int i = 0; i < allies.Count; ++i)
                {
                    alliesNames[i] = allies[i].Name;
                }

                //adds all the allies to bp to current bp
                for (int i = 0; i < allies.Count; ++i)
                {
                    currentTotalBP += allies[i].getBP();
                }

                //check to see if the bp is over 50 and return if true
                if (currentTotalBP >= 50)
                    return;
                else
                {
                    int amountLeft = 50 - currentTotalBP;

                    //gets all of the players cards
                    List<AdventureCard> cards = pc.model.getCards();

                    List<AdventureCard> weapons = null;

                    //loops through all the players cards
                    for (int j = 0; j < cards.Count; ++j)
                    {
                        bool duplicate = false;
                        //checks to see if the card is a weapon
                        if (cards[j].type == AdventureCard.Type.WEAPON)
                        {
                            //if no cards are added it just adds the first weapon card
                            if (weapons.Count == 0)
                                weapons.Add(cards[j]);
                            else 
                            {
                                //loops through all previous weapons
                                for (int w = 0; w < weapons.Count; ++w)
                                {
                                    //check to see if the weapon was a duplicate
                                    if (cards[j].Equals(weapons[w]))
                                    {
                                        duplicate = true;
                                    }
                                }
                                //if not duplicate, it adds the weapon to weapons list
                                if (!duplicate)
                                    weapons.Add(cards[j]);
                            }
                        }
                    }

                    //Sort weapon from highest to lowest
                   weapons = weapons.OrderByDescending(w => w.getBP()).ToList();
                    
                    //loop through the sorted weapons list to play each card until the bp >= 50
                    for (int w = 0; w < weapons.Count; ++w)
                    {
                        //then add weapons to total pb and plays card
                        //cards.play(cards[largest]);
                        currentTotalBP += weapons[w].getBP();
                        
                        //return if bp is >= 50
                        if (currentTotalBP >= 50)
                            return;
                    }                
                }
            }
        }

        public override void DoISponsorAQuest()
        {
            //need to find out how much the winner of the quest gets
            int numShields = GameObject.FindGameObjectWithTag("CurrStory").GetComponent<QuestCard>().stages;
            
            //then need to check if one of the players can win or evolve by winning...


            //if so then 
            //do not sponsor 

            //else
            //if I have sufficient number of foes(with increasing battle points) + 1 for test
            //then sponsor and do 
            //sponor = true; setup1();
             
            throw new NotImplementedException();
        }

        public void setup1()
        {   //might have to take in the quest name and sponsor stages to add the correct cards
            //setup 1

            //first stage = strongest foe with a weapon that u either have 2 or more of in your hand.
            //second stage = test if possible
            //last stage => 50
        }

        public override void doIParticipateInQuest()
        {
            List<AdventureCard> cards = pc.model.getCards();

            int count = 0;
            int foes = 0;
            for(int i = 0; i < cards.Count; i++)
            {
                if (cards[i].getBP() >=10)
                {
                    count++;
                }
                if(cards[i].type == AdventureCard.Type.FOE && cards[i].getBP()<25)
                {
                    foes++;
                }
            }
            if(foes>2 && count > 3)
            {
                //participate in quest
            }
            else
            {
                //i do not participate in quest
            }
            throw new NotImplementedException();
        }

        public override int nextBid(int prev)
        {
            //if valid (IE an increase in bid)
            List<AdventureCard> cards = pc.model.getCards();
            int foeCount = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].type == AdventureCard.Type.FOE && cards[i].getBP() <20)
                {
                    //add to sublist
                    foeCount++;
                }
            }
            if (foeCount>prev) {
                //bid amount of foes possible
                return foeCount;
            }
            else
            {
                //Return -1 to show it isnt possible to bid
                return -1;
            }
            throw new NotImplementedException();
            
        }

        public override void discardAfterWinningTest()//Hand hand)
        {
            //get cards needed
            List<AdventureCard> cards = pc.model.getCards();
            
            for (int i = 0; i < cards.Count; i++)
            {
                //check if the current foe card has les than 20 bp
                if (cards[i].type == AdventureCard.Type.FOE && cards[i].getBP() < 20)
                {
                    //pc.removeCard(cards[i]);
                }
            }
            throw new NotImplementedException();
        }
    }
}