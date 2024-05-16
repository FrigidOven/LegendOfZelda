using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Tiles;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.UISprites;

namespace ZeldaNES.Sprites.UISprites

{
    public class EightSprite : ISprite
    {
        static int SpriteIndex =1;
        static int SpriteFrameCount = 1;
        static int SpriteStallFrameCount = 1;
        
        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        ITile owner;
        public EightSprite(ITile par) {
            
            for (int i = 0; i < SpriteFrameCount; i++)
            {
                Frames[i] = new Rectangle(  UISpriteConstants.Text8SpriteX,
                                            UISpriteConstants.TextSpriteY, 
                                            UISpriteConstants.TextSpriteSize, 
                                            UISpriteConstants.TextSpriteSize);
            }
           
            stallframesCounter = 0;
            frameIndex = 0;
            stallframesCounter = SpriteStallFrameCount;
            this.owner = par;
        }
        public void Update() { 
           
        }
        public void Draw() {
            destination = new Rectangle(
                                            owner.PosX - (UISpriteConstants.TextSpriteSize * GeneralConstants.ImageScale / 2),
                                             owner.PosY - (UISpriteConstants.TextSpriteSize * GeneralConstants.ImageScale / 2),
                                             (3*UISpriteConstants.TextSpriteSize) /4* GeneralConstants.ImageScale,
                                             (3*UISpriteConstants.TextSpriteSize) /4* GeneralConstants.ImageScale);
            TextureManager.TextureManager.Instance.SpriteBatch.Draw(TextureManager.TextureManager.Instance.UIPauseMenuTexture, destination, Frames[frameIndex], Color.White);
        }

    }
}
