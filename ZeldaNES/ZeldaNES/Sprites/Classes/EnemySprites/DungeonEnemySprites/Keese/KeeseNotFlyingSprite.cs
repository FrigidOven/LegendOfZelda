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
using ZeldaNES.NPCs.Classes;
using ZeldaNES.NPCs;
using ZeldaNES.NPCs.Classes.Keese;
using ZeldaNES.NPCs.Classes.Keese.States;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites.Keese
{
    public class KeeseNotFlyingSprite : ISprite
    {
        INPC owner;

        private Rectangle sourceRect;
        private Rectangle destinationRect;

        private int framesStalled = 0;
        private int movementSpeed = 5;

        private Random rnd;
        public KeeseNotFlyingSprite(INPC thisKeese)
        {
            owner = thisKeese;

            rnd = new Random();
            sourceRect = new Rectangle(
            DungeonEnemySpriteConstants.DownFacingSpritesIndex,
            DungeonEnemySpriteConstants.KeeseSpritesIndex,
            DungeonEnemySpriteConstants.SpriteSize,
            DungeonEnemySpriteConstants.SpriteSize);
        }
        public void Update()
        {
            return;
        }

        public void Draw()
        {
            int scale = GeneralConstants.ImageScale;
            Rectangle destination = new Rectangle(
                owner.PosX - DungeonEnemySpriteConstants.SpriteSize / 2 * scale,
                owner.PosY - DungeonEnemySpriteConstants.SpriteSize / 2 * scale,
                DungeonEnemySpriteConstants.SpriteSize * scale,
                DungeonEnemySpriteConstants.SpriteSize * scale);
            Color color = owner.Body().IsTakingDamage ? Color.HotPink : Color.White;
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destination, sourceRect, color);
        }

    }
}
