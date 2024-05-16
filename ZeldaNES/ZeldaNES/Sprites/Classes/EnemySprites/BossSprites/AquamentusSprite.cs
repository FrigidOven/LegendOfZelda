using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Weapons.Classes.EnergyBall;
using ZeldaNES.NPCs;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.NPCs.Classes.Aquamentus;
using ZeldaNES.Factories;

namespace ZeldaNES.Sprites.Classes.EnemySprites.BossSprites
{
    public class AquamentusSprite : ISprite
    {
        AquamentusEnemy owner;
        Texture2D weaponTexture;
        
        private bool isMovingForward = true;
        private int speed = 3;
        private int frameCounter = 0;
        private int currentFrame = DungeonEnemySpriteConstants.AquamentusWalkingSpritesIndex;
        private List<EnergyBall> balls = new List<EnergyBall>();
        private int shootTimer = 0;
        private WeaponFactory weaponfactory;


        public AquamentusSprite(AquamentusEnemy thisOwner)
        {
            this.owner = thisOwner;
        }
        public void Update() 
        {
            // Update the boss position based on its current direction
            owner.PosX = isMovingForward ? owner.PosX - speed : owner.PosX + speed;

            frameCounter++;
            if (frameCounter >= DungeonEnemySpriteConstants.AquamentusWalkingSpritesStallFrameCount)
            {
                frameCounter = 0;
                // Increment currentFrame to switch to the next frame
                currentFrame += DungeonEnemySpriteConstants.SpriteSize;

                // Check if currentFrame exceeds the maximum index for left-facing sprites
                if (currentFrame >= DungeonEnemySpriteConstants.AquamentusWalkingSpritesIndex + 
                                    DungeonEnemySpriteConstants.SpriteSize * DungeonEnemySpriteConstants.AquamentusWalkingSpritesFrameCount)
                {
                    // Reset to the first frame index for left-facing sprites
                    currentFrame = DungeonEnemySpriteConstants.AquamentusWalkingSpritesIndex;
                }
            }

            // Check if the boss has reached the bounds, and change direction if necessary
            if (owner.PosX <= 150* GeneralConstants.ImageScale)      //increase these to set where he walks around farther right, decrease to set farther left
            {
                isMovingForward = false;
            }
            else if (owner.PosX >= 200*GeneralConstants.ImageScale)
            {
                isMovingForward = true;
            }

            shootTimer++;
            // Shoot every 2 seconds
        }

        public void Draw()
        {
            Rectangle sourceRect = new Rectangle(DungeonEnemySpriteConstants.LeftFacingSpritesIndex, currentFrame, DungeonEnemySpriteConstants.SpriteSize, DungeonEnemySpriteConstants.SpriteSize);

            int scale = GeneralConstants.ImageScale;
            Rectangle destinationRect = new Rectangle(
                owner.PosX - DungeonEnemySpriteConstants.SpriteSize / 2 * scale,
                owner.PosY - DungeonEnemySpriteConstants.SpriteSize / 2 * scale,
                DungeonEnemySpriteConstants.SpriteSize * scale,
                DungeonEnemySpriteConstants.SpriteSize * scale);

            Color color = owner.Body().IsTakingDamage ? Color.HotPink : Color.White;

            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destinationRect, sourceRect, color);

            foreach (var ball in balls)
            {
                ball.Draw();
            }
        }
    }
}