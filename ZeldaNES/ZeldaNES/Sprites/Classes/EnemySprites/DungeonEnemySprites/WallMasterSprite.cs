using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;
using ZeldaNES.NPCs.Classes.WallMaster;


namespace ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites
{
    internal class WallMasterSprite : ISprite
    {
        private WallMasterEnemy owner;

        private bool isTriggered;

        private Rectangle sourceRect;
        private Rectangle destinationRect;
        private Rectangle frame1;
        private int framethreshold = 16;
        private int framescount = 0;
        private Rectangle frames;

        public WallMasterSprite(WallMasterEnemy thisWallMaster)
        {
            owner = thisWallMaster;

            frames = new Rectangle(DungeonEnemySpriteConstants.LeftFacingSpritesIndex,
                                       DungeonEnemySpriteConstants.WallMasterWalkingSpritesIndex,
                                       DungeonEnemySpriteConstants.SpriteSize,
                                       DungeonEnemySpriteConstants.SpriteSize);
        }

        public void Update()
        {
            //do not move right now.
            //frame
        
            if (framescount == framethreshold)
            {
                framescount = 0;
            }
            else
            {
                framescount++;
            }
            if (framescount == framethreshold / 2 - 1)
            {
                frames.Y += DungeonEnemySpriteConstants.SpriteSize;
            }
            else if (framescount == framethreshold)
            {
                frames.Y -= DungeonEnemySpriteConstants.SpriteSize;
            }
            
        
        }


        public void Draw()
        {
            // Enemy's position is based on center of sprite so subtract half of sprite size.
            destinationRect = new Rectangle(owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destinationRect, frames, Color.White);
        }
    }
}
