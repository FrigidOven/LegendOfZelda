using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Tiles;
using ZeldaNES.Sprites;
using ZeldaNES.TextureManager;

namespace ZeldaNES.Sprites.Classes.TileSprites
{
    internal class BlackBackgroundSprite : ISprite
    {
        static int SpriteIndex = DungeonTileSpriteConstants.BlackSpriteIndex;
        static int SpriteFrameCount = 1;
        static int SpriteStallFrameCount = 1;

        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        ITile owner;
        public BlackBackgroundSprite(ITile item)
        {

            for (int i = 0; i < SpriteFrameCount; i++)
            {
                Frames[i] = new Rectangle(0,
                                            SpriteIndex + i * DungeonTileSpriteConstants.TileSpriteSize,
                                            DungeonTileSpriteConstants.TileSpriteSize,
                                            DungeonTileSpriteConstants.TileSpriteSize);
            }
            destination = new Rectangle(0, 0, 16 * 16 * GeneralConstants.ImageScale, 16 * 11 * GeneralConstants.ImageScale);
            stallframesCounter = 0;
            frameIndex = 0;
            stallframesCounter = SpriteStallFrameCount;
            owner = item;
        }
        public void Update()
        {
            if (stallframesCounter == SpriteStallFrameCount)
            {
                stallframesCounter = 0;
                frameIndex = (frameIndex + 1) % Frames.Length;
            }
            stallframesCounter++;

        }
        public void Draw()
        {
            destination = new Rectangle(0, 0, 16 * 16 * GeneralConstants.ImageScale, 16 * 11 * GeneralConstants.ImageScale);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.tileTexture, destination, Frames[frameIndex], Color.White);
        }
    }
}
