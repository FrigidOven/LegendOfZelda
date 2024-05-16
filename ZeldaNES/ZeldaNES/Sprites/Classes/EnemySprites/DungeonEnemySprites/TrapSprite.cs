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
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Trap;

namespace ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites
{
    internal class TrapSprite : ISprite
    {
        private TrapEnemy owner;
        private Rectangle sourceRect;
        private Rectangle destinationRect;
        public TrapSprite(TrapEnemy thisTrap)
        {
            owner = thisTrap;
            
            sourceRect = new Rectangle(DungeonEnemySpriteConstants.DownFacingSpritesIndex,
                                       DungeonEnemySpriteConstants.BladeTrapSpritesIndex,
                                       DungeonEnemySpriteConstants.SpriteSize,
                                       DungeonEnemySpriteConstants.SpriteSize);
        }

        public void Update()
        {

            //nothing to update
        }


        public void Draw()
        {
            // Enemy's position is based on center of sprite so subtract half of sprite size.
            destinationRect = new Rectangle(owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destinationRect, sourceRect, Color.White);
        }
    }
}
