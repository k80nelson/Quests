using System;

namespace QuestOTRT
{
    public class Quest : StoryCard
    {
        private int stages;
        public int Stages
        {
            get
            {
                return stages;
            }
        }

        public Quest(string name, int stages) : base(name)
        {
            this.stages = stages;
        }
    }

}