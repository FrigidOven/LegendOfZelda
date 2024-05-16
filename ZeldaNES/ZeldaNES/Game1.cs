using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Regions;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.TextureManager;
using ZeldaNES.Cameras;
using Microsoft.Xna.Framework.Media;
using ZeldaNES.GameStates;
using System.Diagnostics;
using ZeldaNES.UI.PauseMenus;
using ZeldaNES.Controllers;
using ZeldaNES.Controllers.Classes;
using ZeldaNES.Factories;
using ZeldaNES.GameTimer;
using ZeldaNES.Achievement;
using ZeldaNES.UI.StartMenu;
using ZeldaNES.Items;
using ZeldaNES.Physics;


namespace ZeldaNES
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public Region ourRegion;
        public GameState gameRef;
        private List<IController> controllers;

        public PauseMenu ourMenu = new PauseMenu();
        public StartMenu startMenu;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = GeneralConstants.ScreenWidth;
            _graphics.PreferredBackBufferHeight = GeneralConstants.ScreenHeight;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            gameRef = GameState.GenInstance(this);
        }
        protected override void Initialize()
        {
            base.Initialize();
            startMenu = new StartMenu();
            ourMenu.GenerateMapFromRegion(ourRegion);
            controllers = new List<IController>();
            controllers.Add(new KeyboardController(ourRegion));
            controllers.Add(new MouseController(ourRegion));
            ourMenu.ReadInventory(ourRegion.players[0]);
        }
        public void Reset()
        {
            ourRegion = RegionGenerator.gen("RegionFiles/Sprint4Dungeon.yaml");
            ourRegion.ResetQuadtree();
            ourRegion.Initialize();
            ourRegion.PopulateReference();
            
            

            controllers = new List<IController>();
            controllers.Add(new KeyboardController(ourRegion));
            controllers.Add(new MouseController(ourRegion));
            ourMenu.ReadInventory(ourRegion.players[0]);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.TextureManager.GenInstance(Content, this._spriteBatch);
            ourRegion = RegionGenerator.gen("RegionFiles/Sprint4Dungeon.yaml");
            ourRegion.PopulateReference();
            ourRegion.Initialize();


            TextureManager.TextureManager.GenInstance(Content, _spriteBatch);
            SoundManager.SoundManager.GenInstance(Content);
            AchievementTracker.GenInstance();
            GameTimeTracker.GenInstance();
            MediaPlayer.IsRepeating = true;

            ItemFactory.GenInstance();  //TODO: texturemanager geninstance called twice. do i need to do that too??
            
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GameTimeTracker.Instance.Update(gameTime);

            SoundManager.SoundManager.Instance.Update(gameTime);

            foreach (IController controller in controllers)
            {
                controller.Update();
            }
                      
            if (!GameState.Instance.PauseScreenMode || !GameState.Instance.deathMode)
            {
                ourRegion.Update();
            }
            startMenu.Update();
            ourMenu.ReadInventory(ourRegion.players[0]);

            ourMenu.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // runs only once per frame, ensures that sprites aren't blurry when scaled up.
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, PlayerCamera.Instance.Transform);
            ourRegion.Draw();
            _spriteBatch.End();

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, UICamera.Instance.Transform);
            ourMenu.Draw();
            startMenu.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
