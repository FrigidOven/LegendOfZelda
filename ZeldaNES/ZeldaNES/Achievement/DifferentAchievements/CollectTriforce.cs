using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;

namespace ZeldaNES.Achievement.DifferentAchievements
{
    internal class CollectTriforce : IAchievement
    {
        
        public CollectTriforce()
        {
            completionMessage = "ACHIEVEMENT GET: COLLECT THE TRIFORCE";
        }
        public string completionMessage { get; set; }
        public bool IsComplete {  get; set; }
        public void UpdateStatus()
        {
            if(AchievementTracker.Instance.triforceCollected)
            {
                IsComplete = true;
            }
        }

        
    }
}
