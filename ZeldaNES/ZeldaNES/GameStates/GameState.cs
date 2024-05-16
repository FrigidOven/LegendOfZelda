using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Tiles;
using ZeldaNES.Tiles.Classes;

namespace ZeldaNES.GameStates
{


    public sealed class GameState
    {
        private static GameState instance = null;
        private static readonly Object padlock = new object();
       
        public bool EditorMode = false;
        public bool PauseScreenMode = false;
        public bool StartMenuMode = true;
        public bool deathMode = false;
        public bool WinMode = false;
        public Game1 gameRef;
        public String currentSaveString = "";
        public int winModeTimer = 0;
        public ITile winBackground = new BlackBackgroundTile();
    
        private GameState(Game1 gameRef) 
        {
            this.gameRef = gameRef;
           
        }
        public static GameState Instance
        {
            get
            {
                    return instance;
                
            }
        }
        public static GameState GenInstance(Game1 gameRef)
        {
          
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new GameState(gameRef);
                    }
                    return instance;
                }
            
        }

    }
}
