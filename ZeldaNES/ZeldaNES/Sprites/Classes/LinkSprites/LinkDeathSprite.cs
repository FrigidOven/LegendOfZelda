using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;

namespace ZeldaNES.Sprites.Classes.LinkSprites
{
    internal class LinkDeathSprite : ISprite
    {
        private Rectangle frame;
        private Rectangle destinationRect;

        private ILink link;
        public LinkDeathSprite(ILink link)
        {
            destinationRect = new Rectangle(link.PosX - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2),
                                            link.PosY - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2),
                                            GeneralConstants.ImageScale * LinkSpriteConstants.SpriteSize,
                                            GeneralConstants.ImageScale * LinkSpriteConstants.SpriteSize);

            frame = new Rectangle(LinkSpriteConstants.DownFacingSpritesIndex,
                                          LinkSpriteConstants.DownFacingSpritesIndex,
                                          LinkSpriteConstants.SpriteSize,
                                          LinkSpriteConstants.SpriteSize);

            this.link = link;
            link.IsBusy = true;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            destinationRect.X = link.PosX - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2);
            destinationRect.Y = link.PosY - GeneralConstants.ImageScale * (LinkSpriteConstants.SpriteSize / 2);


            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.playerTexture,
                destinationRect, frame, Color.Red);
        }
    }
}
