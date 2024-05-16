using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Achievement.DifferentAchievements
{
    internal class BombableWallBombed : IAchievement
    {
        public BombableWallBombed()
        {
            completionMessage = "ACHIEVEMENT GET: SECRET DOORWAY";
        }
        public string completionMessage { get; set; }
        public bool IsComplete { get; set; }
        public void UpdateStatus()
        {
            if (AchievementTracker.Instance.wallBombed)
            {
                IsComplete = true;
            }
        }
    }
}
