using System;

namespace QuestOTRT
{
    public class Tournament : StoryCard
    {
        private int shields;
        public int Shields
        {
            get
            {
                return shields;
            }
        }

        public Tournament(string name, int shields)
            : base(name)
        {
            this.shields = shields;
        }
    }
}
