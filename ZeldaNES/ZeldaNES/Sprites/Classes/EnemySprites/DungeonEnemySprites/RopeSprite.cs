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
using ZeldaNES.NPCs.Classes.Rope;

namespace ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites
{
    public class RopeSprite : ISprite
    {
        RopeEnemy owner;

        Rectangle destination;
        Rectangle frame;

        private int animationTimer;
        private int directionTimer;
        private int direction;
        public RopeSprite(RopeEnemy owner)
        {
            this.owner = owner;

            destination = new Rectangle(
                                            owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);

            frame = new Rectangle(DungeonEnemySpriteConstants.LeftFacingSpritesIndex+(owner.leftOrRight* DungeonEnemySpriteConstants.SpriteSize),
                                            DungeonEnemySpriteConstants.RopeSpriteIndex,
                                            DungeonEnemySpriteConstants.SpriteSize,
                                            DungeonEnemySpriteConstants.SpriteSize);
            animationTimer = 0;
            directionTimer = 0;
            direction = -1;
        }

        public void ChangeDirection(int direction)
        {
            
        }
        public void Update()
        {
            animationTimer++;
            directionTimer++;

            if (animationTimer == 10)
            {
                frame.Y += DungeonEnemySpriteConstants.SpriteSize;
            }
            if(animationTimer == 20) 
            {
                frame.Y -= DungeonEnemySpriteConstants.SpriteSize;
                animationTimer = 0;
            }
            if(directionTimer == 100)
            {
                if (direction == -1)
                {
                    frame.X += DungeonEnemySpriteConstants.SpriteSize;
                    direction = 1;
                }
                else
                {
                    frame.X -= DungeonEnemySpriteConstants.SpriteSize;
                    direction = -1;
                }
                directionTimer = 0;
            }
            
        }

        public void Draw()
        {
            destination = new Rectangle(
                                            owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            Color color = owner.Body().IsTakingDamage ? Color.HotPink : Color.White;
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destination, frame, color);
        }
    }
}
