using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;

namespace ZeldaNES.Sprites.Classes.EnemySprites.BossSprites.Dodongo
{
    public class DodongoWalkingDownSprite : ISprite
    {
        private Rectangle[] frames;
        private Rectangle destinationRect;

        private int stallFrameCounter;
        private int frameIndex;

        private INPC dodongo;
        public DodongoWalkingDownSprite(INPC dodongo)
        {
            frames = new Rectangle[DungeonEnemySpriteConstants.DodongoWalkingSpritesFrameCount];
            for (int i = 0; i < DungeonEnemySpriteConstants.DodongoWalkingSpritesFrameCount; i++)
            {
                frames[i] = new Rectangle(DungeonEnemySpriteConstants.DownFacingSpritesIndex,
                                          DungeonEnemySpriteConstants.DodongoWalkingSpritesIndex + i * DungeonEnemySpriteConstants.SpriteSize,
                                          DungeonEnemySpriteConstants.SpriteSize,
                                          DungeonEnemySpriteConstants.SpriteSize);
            }
            destinationRect = new Rectangle(dodongo.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            dodongo.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            stallFrameCounter = 0;
            frameIndex = 0;

            this.dodongo = dodongo;
        }
        public void Update()
        {
            if (stallFrameCounter == DungeonEnemySpriteConstants.DodongoWalkingSpritesStallFrameCount)
            {
                stallFrameCounter = 0;
                frameIndex = (frameIndex + 1) % frames.Length;
            }
            stallFrameCounter++;
        }
        public void Draw()
        {
            destinationRect.X = dodongo.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2);
            destinationRect.Y = dodongo.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2);

            Color color = dodongo.Body().IsTakingDamage ? Color.HotPink : Color.White;
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destinationRect, frames[frameIndex], color);
        }
    }
}
