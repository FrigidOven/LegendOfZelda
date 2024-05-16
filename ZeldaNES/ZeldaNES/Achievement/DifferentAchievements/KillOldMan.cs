using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Regions;

namespace ZeldaNES.Achievement.DifferentAchievements
{
    internal class KillOldMan : IAchievement
    {
        public KillOldMan()
        {
            completionMessage = "ACHIEVEMENT GET: OLD MAN ELIMINATED";

            IsComplete = false;
        }

        public string completionMessage { get; set; }
        public bool IsComplete { get; set; }
        public void UpdateStatus()
        {
            if (AchievementTracker.Instance.oldManKilled)
            {
                IsComplete = true;
            }
        }

        public void DisplayCompletionStatus()
        {

        }
    }
}
