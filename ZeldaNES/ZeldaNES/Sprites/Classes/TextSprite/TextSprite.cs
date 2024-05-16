using Microsoft.Xna.Framework;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Tiles;


namespace ZeldaNES.Sprites
{
    public class TextSprite : ISprite
    {
        public string message1 = "EASTMOST PENNINSULA";
        public string message2 = "IS THE SECRET.";
        public ITile owner;
        public int offset = 40;
        public TextSprite(ITile item) {
            owner = item;
        }
        public void Draw()
        {
            Vector2 position = new Vector2(owner.PosX - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize / 2),
                                   owner.PosY - GeneralConstants.ImageScale * (DungeonTileSpriteConstants.TileSpriteSize/ 2));
            TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont, message1, position, Color.White);
            TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont, message2, new Vector2(position.X + offset, position.Y + offset), Color.White);
        }
        public void Update() { 
            
        }
    }
}
