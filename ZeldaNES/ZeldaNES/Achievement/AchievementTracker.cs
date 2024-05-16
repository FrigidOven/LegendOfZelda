using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Achievement.DifferentAchievements;
using ZeldaNES.Regions;
using Microsoft.Xna.Framework;
using ZeldaNES.Game_Constants;
using Microsoft.Xna.Framework.Content;

namespace ZeldaNES.Achievement
{
    public sealed class AchievementTracker
    {
        private static AchievementTracker instance = null;
        private static readonly Object padlock = new object();

        List<IAchievement> achievements;

        IAchievement achievementOnDisplay;

        IRegion region;

        private int incompleteAchievements;

        private int displayTimer;

        

        // Stats to track for achievement purposes
        public int enemiesKilled;
        public bool triforceCollected;
        public bool oldManKilled;
        public int itemsCollected;
        public bool keyItemCollected;
        public bool wallBombed;
        public float timeToCollectTriforce;
        public AchievementTracker() 
        {
            achievements = new List<IAchievement>();

            

            achievements.Add(new KillTenEnemies());
            achievements.Add(new CollectTriforce());
            achievements.Add(new KillOldMan());
            achievements.Add(new BombableWallBombed());
            achievements.Add(new DungeonItemFound());

            incompleteAchievements = achievements.Count;

            displayTimer = 0;

            // Stat initialization
            enemiesKilled = 0;
            triforceCollected = false;
            oldManKilled = false;
            itemsCollected = 0;
            keyItemCollected = false;
            wallBombed = false;
            timeToCollectTriforce = 0;
        }

        public void UpdateAchievementStatus()
        {
            foreach (IAchievement achievement in AchievementTracker.Instance.achievements)
            {
                if (!achievement.IsComplete)
                {
                    achievement.UpdateStatus();
                    if (achievement.IsComplete)
                    {
                        AchievementTracker.Instance.achievementOnDisplay = achievement;
                    }
                }

            }

            
        }
        public void DisplayRecentAchievement()
        {
            if (AchievementTracker.Instance.achievementOnDisplay != null)
            {
                displayTimer++;
                if(displayTimer < 500)
                {
                    Vector2 position = new Vector2(GeneralConstants.ScreenWidth/2 - (float)(GeneralConstants.ScreenWidth * .25), GeneralConstants.ScreenHeight/2 - (float)(GeneralConstants.ScreenHeight*.33));

                    TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont,
                        AchievementTracker.Instance.achievementOnDisplay.completionMessage, position, Color.White);
                }
                else
                {
                    AchievementTracker.Instance.achievementOnDisplay = null;
                    displayTimer = 0;
                }
            }
        }

        public void DisplayStats()
        {
            if(AchievementTracker.Instance.achievementOnDisplay == null && AchievementTracker.Instance.triforceCollected)
            {
                displayTimer++;
                if (displayTimer < 1000)
                {
                    
                    Vector2 position1 = new Vector2(GeneralConstants.ScreenWidth / 2 - (float)(GeneralConstants.ScreenWidth * .4),
                        GeneralConstants.ScreenHeight / 2 - (float)(GeneralConstants.ScreenHeight * .333));
                    Vector2 position2 = new Vector2(GeneralConstants.ScreenWidth / 2 - (float)(GeneralConstants.ScreenWidth * .4),
                        GeneralConstants.ScreenHeight / 2 - (float)(GeneralConstants.ScreenHeight * .267));
                    Vector2 position3 = new Vector2(GeneralConstants.ScreenWidth / 2 - (float)(GeneralConstants.ScreenWidth * .4),
                        GeneralConstants.ScreenHeight / 2 - (float)(GeneralConstants.ScreenHeight * .233));
                    Vector2 position4 = new Vector2(GeneralConstants.ScreenWidth / 2 - (float)(GeneralConstants.ScreenWidth * .4),
                        GeneralConstants.ScreenHeight / 2 - (float)(GeneralConstants.ScreenHeight * .2));

                    TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont,
                            "GAME STATS", position1, Color.White);
                    TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont,
                            "Enemies Killed: " + AchievementTracker.Instance.enemiesKilled, position2, Color.White);
                    TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont,
                            "Items Picked-Up: " + AchievementTracker.Instance.itemsCollected, position3, Color.White);
                    TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont,
                            "Time: " + string.Format("{0:N2}" + "s", AchievementTracker.Instance.timeToCollectTriforce), position4, Color.White);

                }
            }
        }

        public static AchievementTracker Instance
        {
            get
            {
                return instance;

            }
        }

        public static AchievementTracker GenInstance()
        {

            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new AchievementTracker();
                }
                return instance;
            }

        }

    }
}
