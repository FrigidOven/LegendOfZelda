using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;

namespace ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites
{
    public class OldManSprite : ISprite
    {
        

        Rectangle frame;
        Rectangle destination;
        INPC owner;
        public OldManSprite(INPC owner) 
        {
            this.owner = owner;
            destination = new Rectangle(
                                        owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                        owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                        GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                        GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);
            frame = new Rectangle(DungeonEnemySpriteConstants.UpFacingSpritesIndex,
                                            DungeonEnemySpriteConstants.OldManSpriteIndex,
                                            DungeonEnemySpriteConstants.SpriteSize,
                                            DungeonEnemySpriteConstants.SpriteSize);
        }
        public void Update()
        {

        }
        public void Draw()
        {
            destination = new Rectangle(
                                        owner.PosX - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                        owner.PosY - GeneralConstants.ImageScale * (DungeonEnemySpriteConstants.SpriteSize / 2),
                                        GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize,
                                        GeneralConstants.ImageScale * DungeonEnemySpriteConstants.SpriteSize);

            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.npcTexture, destination, frame, Color.White);
        }
    }
}
