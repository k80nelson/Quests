using System;

namespace QuestOTRT
{

    public abstract class Strategy : GameElement
    {
        protected PlayerController pc;

        public Strategy(PlayerController pc)
        {
        }

        public abstract void doIParticipationInTournament();

        public abstract void DoISponsorAQuest();

        public abstract void doIParticipateInQuest();

        public abstract int nextBid(int prevBid);

        public abstract void discardAfterWinningTest();// Hand hand);
    }
}
