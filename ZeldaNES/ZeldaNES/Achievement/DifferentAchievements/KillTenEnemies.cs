using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.NPCs;
using ZeldaNES.Regions;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Achievement.DifferentAchievements
{
    internal class KillTenEnemies : IAchievement
    {
        

        public string completionMessage { get; set; }
        

        public bool IsComplete { get; set; }

        public int Recency { get; set; }
        public KillTenEnemies()
        {
            

            IsComplete = false;

            completionMessage = "ACHIEVEMENT GET: KILL 10 ENEMIES";
        }

        
        public void UpdateStatus()
        {

            if (AchievementTracker.Instance.enemiesKilled >= 10 && !IsComplete)
            {
                IsComplete = true;
                DisplayCompletionStatus();
            }
        }

        public void DisplayCompletionStatus()
        {
            
        }
    }
}
