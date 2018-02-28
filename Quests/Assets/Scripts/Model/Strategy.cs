using System;

namespace QuestOTRT
{

    public abstract class Strategy
    {
        public Strategy()
        {
        }

        public abstract void doIParticipationInTournament();

        public abstract void DoISponsorAQuest();

        public abstract void doIParticipateInQuest();

        public abstract void nextBid();

        public abstract void discardAfterWinningTest();
    }
}
