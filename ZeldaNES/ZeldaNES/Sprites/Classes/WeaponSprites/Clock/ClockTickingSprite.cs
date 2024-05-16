using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.Sprites.Classes.ItemSprites;
using ZeldaNES.Sprites.Classes.LinkWeaponSprites;
using ZeldaNES.Weapons;

namespace ZeldaNES.Sprites.Classes.WeaponSprites.Bomb
{
    public class ClockTickingSprite : ISprite
    {
        static int SpriteIndex = ItemSpriteConstants.ClockSpriteIndex;
        static int SpriteFrameCount = ItemSpriteConstants.ClockSpriteFrameCount;
        static int SpriteStallFrameCount = ItemSpriteConstants.ClockSpriteStallFrameCount;

        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        IWeapon owner;
        public ClockTickingSprite(IWeapon item)
        {

            for (int i = 0; i < SpriteFrameCount; i++)
            {
                Frames[i] = new Rectangle(0,
                                            SpriteIndex + i * ItemSpriteConstants.SpriteSize,
                                            ItemSpriteConstants.SpriteSize,
                                            ItemSpriteConstants.SpriteSize);
            }
            destination = new Rectangle(item.PosX - GeneralConstants.ImageScale * (ItemSpriteConstants.SpriteSize / 2),
                                            item.PosY - GeneralConstants.ImageScale * (ItemSpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * ItemSpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * ItemSpriteConstants.SpriteSize);
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
            destination = new Rectangle(owner.PosX - GeneralConstants.ImageScale * (ItemSpriteConstants.SpriteSize / 2),
                                            owner.PosY - GeneralConstants.ImageScale * (ItemSpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * ItemSpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * ItemSpriteConstants.SpriteSize);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.itemTexture, destination, Frames[frameIndex], Color.White);
        }


    }
}
