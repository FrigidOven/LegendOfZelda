using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.NPCs;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.TextureManager;

namespace ZeldaNES.Sprites.Classes.EnemySprites
{
    public class StalfoSprite : ISprite
    {
        static int SpriteIndex = DungeonEnemySpriteConstants.StalfoSpritesIndex;
        static int SpriteFrameCount = DungeonEnemySpriteConstants.StalfoSpritesFrameCount;
        static int SpriteStallFrameCount = DungeonEnemySpriteConstants.StalfoSpritesStallFrameCount;
        static int SpriteDirectionFacing = DungeonEnemySpriteConstants.DownFacingSpritesIndex;

        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        INPC owner;
        public StalfoSprite(INPC owner)
        {

            for (int i = 0; i < SpriteFrameCount; i++)
            {
                Frames[i] = new Rectangle(
                                            SpriteDirectionFacing,
                                            SpriteIndex + i * DungeonEnemySpriteConstants.SpriteSize,
                                            DungeonEnemySpriteConstants.SpriteSize,
                                            DungeonEnemySpriteConstants.SpriteSize);
            }
            destination = new Rectangle(
                                        owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                        owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                        GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                        GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            stallframesCounter = 0;
            frameIndex = 0;
            stallframesCounter = SpriteStallFrameCount;
            this.owner = owner;
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
            destination = new Rectangle(
                                            owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            Color color = owner.Body().IsTakingDamage ? Color.HotPink : Color.White;
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destination, Frames[frameIndex], color);
        }

    }
}
