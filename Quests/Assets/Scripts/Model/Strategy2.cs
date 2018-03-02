﻿using System;
using System.Collections.Generic;
using System.Linq;

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

            if (pc.player.BP >= 50)
                return;
            else
            {
                currentTotalBP = pc.player.BP;
                List<Ally> allies = pc.player.getAllies();
                String[] alliesNames = null;
                for (int i = 0; i < allies.Count; ++i)
                {
                    alliesNames[i] = allies[i].Name;
                }

                for (int i = 0; i < allies.Count; ++i)
                {
                    currentTotalBP += allies[i].getBP(alliesNames);
                }

                if (currentTotalBP >= 50)
                    return;
                else
                {
                    int amountLeft = 50 - currentTotalBP;
                    List<AdventureCard> cards = pc.player.getCards();

                    String[] cardNames = null;
                    for (int j = 0; j < cards.Count; ++j)
                    {
                        cardNames[j] = cards[j].Name;
                    }

                    List<AdventureCard> weapons = null;
                    //add all weapon cards to a different array as long as its not a duplicate
                    for (int j = 0; j < cards.Count; ++j)
                    {
                        bool duplicate = false;
                        if (cards[j] is Weapon)
                        {
                            if (weapons.Count == 0)
                                weapons.Add(cards[j]);
                            else
                            {
                                for (int w = 0; w < weapons.Count; ++w)
                                {
                                    if (cards[j].Equals(weapons[w]))
                                    {
                                        duplicate = true;
                                    }
                                }

                                if (!duplicate)
                                    weapons.Add(cards[j]);
                            }
                        }
                    }

                    //Sort weapon from highest to lowest
                   weapons = weapons.OrderByDescending(w => w.getBP(new String[] { w.Name })).ToList();
                    
                    //loop through the sorted weapons list to play each card until the bp >= 50
                    for (int w = 0; w < weapons.Count; ++w)
                    {
                        //then add weapons to total pb and plays card
                        //cards.play(cards[largest]);
                        currentTotalBP += weapons[w].getBP(new String[] { weapons[w].Name });
                        
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

            throw new NotImplementedException();
        }

        public override void nextBid()
        {
            throw new NotImplementedException();
        }

        public override void discardAfterWinningTest(Hand hand)
        {
            //hand.getAllies().Count
            throw new NotImplementedException();
        }
    }
}