using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;

namespace ZeldaNES.Sprites.Classes.LinkSprites
{
    public class LinkSwingingSwordLeftSprite : ISprite
    {
        private Rectangle[] frames;
        private Rectangle destinationRect;

        private int stallFrameCounter;
        private int frameIndex;

        private ILink link;

        public LinkSwingingSwordLeftSprite(ILink link)
        {
            frames = new Rectangle[LinkSpriteConstants.SwingingSwordSpritesFrameCount];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = new Rectangle(LinkSpriteConstants.LeftFacingSpritesIndex,
                                          LinkSpriteConstants.SwingingSwordSpritesIndex + i * LinkSpriteConstants.SpriteSize,
                                          LinkSpriteConstants.SpriteSize,
                                          LinkSpriteConstants.SpriteSize);
            }
            destinationRect = new Rectangle(link.PosX - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2),
                                            link.PosY - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * LinkSpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * LinkSpriteConstants.SpriteSize);
            stallFrameCounter = 0;
            frameIndex = 0;


            this.link = link;
            this.link.IsBusy = true;
        }
        public void Update()
        {
            if (frameIndex == frames.Length - 1 && stallFrameCounter == LinkSpriteConstants.SwingingSwordSpritesStallFrameCount)
            {
                link.IsBusy = false;
                link.Stop();
            }
            if (stallFrameCounter == LinkSpriteConstants.SwingingSwordSpritesStallFrameCount)
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
