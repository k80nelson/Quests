using System;
using System.Collections.Generic;

namespace QuestOTRT
{
    public class Strategy2 : Strategy
    {
        public Strategy2()
        {
        }

        public override void doIParticipationInTournament(Player p)
        {
            //participation button is clicked in the back end!
            int currentTotalBP = 0;

            if (p.BP >= 50)
                return;
            else
            {
                currentTotalBP = p.BP;
                List<Ally> allies = p.getAllies();
                String[] alliesNames = null;
                for (int i = 0; i < allies.Count;  ++i)
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
                    List<AdventureCard> cards = p.getCards();

                    int largest = 0;
                    int largestAmount = -1;
                    String[] cardNames = null;
                    for (int j = 0; j < cards.Count; ++j)
                    {
                        cardNames[j] = cards[j].Name;
                    }


                        for (int j = 0;j < cards.Count; ++j)
                    {
                        if(cards[j] is Weapon)
                        {
                            if(largestAmount == -1)
                            {
                                largest = j;
                                largestAmount = cards[j].getBP(cardNames);
                            }
                            else
                            {
                                if (largestAmount < cards[j].getBP(cardNames))
                                {
                                    largest = j;
                                    largestAmount = cards[j].getBP(cardNames);
                                }
                            }
                        }
                    }

                    //takes the largest variable and plays that card
                    //cards.play(cards[largest]);

                    currentTotalBP += largestAmount;

                    if (currentTotalBP >= 50)
                        return;


                }


            }
            throw new NotImplementedException();
        }

        public override void DoISponsorAQuest()
        {
            throw new NotImplementedException();
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