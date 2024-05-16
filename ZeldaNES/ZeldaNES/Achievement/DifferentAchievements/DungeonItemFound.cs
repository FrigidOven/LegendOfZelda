using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Achievement.DifferentAchievements
{
    internal class DungeonItemFound : IAchievement
    {
        public DungeonItemFound()
        {
            completionMessage = "ACHIEVEMENT GET: DUNGEON ITEM FOUND";
        }
        public string completionMessage { get; set; }
        public bool IsComplete { get; set; }
        public void UpdateStatus()
        {
            if (AchievementTracker.Instance.keyItemCollected)
            {
                IsComplete = true;
            }
        }
    }
}
