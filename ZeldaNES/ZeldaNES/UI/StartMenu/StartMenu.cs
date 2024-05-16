using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.UISprites;
using Microsoft.Xna.Framework.Input;
using ZeldaNES.GameStates;

namespace ZeldaNES.UI.StartMenu
{
    public class StartMenu
    {
        private ISprite sprite;

        public int PosX
        {
            get; set;
        }
        public int PosY
        {
            get; set;
        }

        public StartMenu()
        {
            PosX = UISpriteConstants.StartScreenX;
            PosY = UISpriteConstants.StartScreenY;
            sprite = new StartMenuSprite(this);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw()
        {
            if (GameState.Instance.StartMenuMode)
            {
                sprite.Draw();
            }
        }
    }

    
}