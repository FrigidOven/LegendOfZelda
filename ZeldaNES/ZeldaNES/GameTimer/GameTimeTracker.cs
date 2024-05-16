using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Achievement;
using ZeldaNES.Regions;
using Microsoft.Xna.Framework;

namespace ZeldaNES.GameTimer
{
    public sealed class GameTimeTracker
    {
        private static GameTimeTracker instance = null;
        private static readonly Object padlock = new object();

        
        private float totalElapsedTime;
        
        public GameTimeTracker()
        {
            
            totalElapsedTime = 0;
        }
        public static GameTimeTracker Instance
        {
            get
            {
                return instance;

            }
        }

        public static GameTimeTracker GenInstance()
        {

            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new GameTimeTracker();
                }
                return instance;
            }

        }

        public void Update(GameTime gameTime)
        {
            totalElapsedTime = (float)gameTime.TotalGameTime.TotalSeconds;
        }

        public float GetElapsedTime()
        {
            return totalElapsedTime;
        }
    }
}
