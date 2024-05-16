﻿using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Doors1;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Microsoft.Xna.Framework;

namespace ZeldaNES.Sprites.Classes.DoorSprites.ShutDoorSprites
{
    public class WestShutDoorSprite : ISprite
    {
        private IDoor owner;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        int Size = DungeonTileSpriteConstants.DoorSpriteSize;

        public WestShutDoorSprite(IDoor door)
        {
            owner = door;
            int SpriteIndexX = DungeonTileSpriteConstants.WestDoorSpritesIndex;
            int SpriteIndexY = DungeonTileSpriteConstants.ShutDoorSpritesIndex;
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

        public void Update()
        {
            //nothing happens because its a tile lol
        }

        public void Draw()
        {
            destinationRect = new Rectangle(
                owner.PosX - GeneralConstants.ImageScale * Size / 2,
                owner.PosY - GeneralConstants.ImageScale * Size / 2,
                GeneralConstants.ImageScale * Size,
                GeneralConstants.ImageScale * Size);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.tileTexture, destinationRect, sourceRect, Color.White);
        }
    }
}
