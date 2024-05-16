using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Tiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ZeldaNES.Doors1;
using System.Drawing;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
namespace ZeldaNES.Sprites.Classes.DoorSprites.HiddenDoorSprites
{
	public class SouthHiddenDoorSprite : ISprite
	{
        private IDoor owner;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        int Size;
        public SouthHiddenDoorSprite(IDoor door)
        {
            this.owner = door;
            int SpriteIndexX = DungeonTileSpriteConstants.SouthDoorSpritesIndex;
            int SpriteIndexY = DungeonTileSpriteConstants.HiddenDoorSpritesIndex;
            Size = DungeonTileSpriteConstants.DoorSpriteSize;
            sourceRect = new Rectangle(
                SpriteIndexX,
                SpriteIndexY,
                Size,
                Size);

            destinationRect = new Rectangle(
                owner.PosX - GeneralConstants.ImageScale * Size / 2,
                owner.PosY - GeneralConstants.ImageScale * Size / 2, 
                GeneralConstants.ImageScale * Size,
                GeneralConstants.ImageScale * Size);
        }

        public void Update() {
            //nothing happens because its a tile lol
        }

        public void Draw()
        {
            destinationRect = new Rectangle(
               owner.PosX - GeneralConstants.ImageScale * Size / 2,
               owner.PosY - GeneralConstants.ImageScale * Size / 2,
               GeneralConstants.ImageScale * Size,
               GeneralConstants.ImageScale * Size);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.tileTexture, destinationRect, sourceRect, Microsoft.Xna.Framework.Color.White);
        }
    }
}
