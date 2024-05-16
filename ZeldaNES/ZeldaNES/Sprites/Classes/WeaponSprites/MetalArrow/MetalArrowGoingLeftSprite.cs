using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.LinkWeaponSprites;
using ZeldaNES.Weapons;

namespace ZeldaNES.Sprites.Classes.WeaponSprites.MetalArrow
{
    public class MetalArrowGoingLeftSprite : ISprite
    {
        private Rectangle[] frames;
        private Rectangle destinationRect;

        private int stallFrameCounter;
        private int frameIndex;

        private IWeapon weapon;

        public MetalArrowGoingLeftSprite(IWeapon weapon)
        {
            frames = new Rectangle[WeaponSpriteConstants.MetalArrowSpritesFrameCount];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = new Rectangle(WeaponSpriteConstants.LeftFacingSpritesIndex,
                                          WeaponSpriteConstants.MetalArrowSpritesIndex + i * WeaponSpriteConstants.SpriteSize,
                                          WeaponSpriteConstants.SpriteSize,
                                          WeaponSpriteConstants.SpriteSize);
            }
            destinationRect = new Rectangle(weapon.PosX - GeneralConstants.ImageScale * (WeaponSpriteConstants.SpriteSize / 2),
                                            weapon.PosY - GeneralConstants.ImageScale * (WeaponSpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * WeaponSpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * WeaponSpriteConstants.SpriteSize);
            stallFrameCounter = 0;
            frameIndex = 0;
            this.weapon = weapon;
        }
        public void Update()
        {
            if (stallFrameCounter == WeaponSpriteConstants.MetalArrowSpritesStallFrameCount)
            {
                stallFrameCounter = 0;
                frameIndex = (frameIndex + 1) % frames.Length;
            }
            stallFrameCounter++;
        }
        public void Draw()
        {
            destinationRect.X = weapon.PosX - GeneralConstants.ImageScale * (WeaponSpriteConstants.SpriteSize / 2);
            destinationRect.Y = weapon.PosY - GeneralConstants.ImageScale * (WeaponSpriteConstants.SpriteSize / 2);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.weaponTexture, destinationRect, frames[frameIndex], Color.White);
        }
    }
}
