using Microsoft.Xna.Framework;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.UISprites;
using ZeldaNES.UI.StartMenu;
using ZeldaNES.GameStates;

namespace ZeldaNES.Sprites.Classes.TileSprites

{ 
    public class StartMenuSprite : ISprite
    {
        private StartMenu owner;
        private Rectangle destination;

        public StartMenuSprite(StartMenu owner) 
        {
            this.owner = owner;
            this.destination = new Rectangle(
                0, 
                0, 
                UISpriteConstants.StartScreenWidth * GeneralConstants.ImageScale, 
                UISpriteConstants.StartScreenHeight * GeneralConstants.ImageScale
            );
        }

        public void Update() 
        { 
            // Do nothing
        }

        public void Draw() 
        {
            if (GameState.Instance.StartMenuMode)
            {
                Rectangle source = new Rectangle(owner.PosX, owner.PosY, UISpriteConstants.StartScreenWidth, UISpriteConstants.StartScreenHeight);
                TextureManager.TextureManager.Instance.SpriteBatch.Draw(
                    TextureManager.TextureManager.Instance.UIStartScreenTexture, 
                    destination, 
                    source,
                    Color.White
                );
            } 
        }
    }
}