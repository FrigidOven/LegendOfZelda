using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Players.Link;
using ZeldaNES.Game_Constants;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Sprites.Classes.LinkWeaponSprites;
using ZeldaNES.Weapons.Classes.Fire;

namespace ZeldaNES.Sprites.Classes.LinkSprites
{
    public class LinkWalkingUpSprite : ISprite
    {
        private Rectangle[] frames;
        private Rectangle destinationRect;

        private int stallFrameCounter;
        private int frameIndex;

        private ILink link;

        public LinkWalkingUpSprite(ILink link)
        {
            frames = new Rectangle[LinkSpriteConstants.WalkingSpritesFrameCount];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = new Rectangle(LinkSpriteConstants.UpFacingSpritesIndex,
                                          LinkSpriteConstants.WalkingSpritesIndex + i * LinkSpriteConstants.SpriteSize,
                                          LinkSpriteConstants.SpriteSize,
                                          LinkSpriteConstants.SpriteSize);
            }
            destinationRect = new Rectangle(link.PosX - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2),
                                            link.PosY - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * LinkSpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * LinkSpriteConstants.SpriteSize);

            // set to max so that first step always happens when walking
            stallFrameCounter = LinkSpriteConstants.WalkingSpritesStallFrameCount;
            frameIndex = 0;


            this.link = link;
        }
        public void Update()
        {
            if (stallFrameCounter == LinkSpriteConstants.WalkingSpritesStallFrameCount)
            {
                stallFrameCounter = 0;
                frameIndex = (frameIndex + 1) % frames.Length;
            }
            stallFrameCounter++;
        }
        public void Draw()
        {
            destinationRect.X = link.PosX - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2);
            destinationRect.Y = link.PosY - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2);

            Color color = link.IsTakingDamage ? LinkSpriteConstants.DamagedColor : Color.White;
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.playerTexture, destinationRect, frames[frameIndex], color);
        }
    }
}
