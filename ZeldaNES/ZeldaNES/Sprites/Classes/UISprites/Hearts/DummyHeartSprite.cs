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
    public class DummyHeartSprite : ISprite
    {
        static int SpriteIndex =1;
        static int SpriteFrameCount = 1;
        static int SpriteStallFrameCount = 1;
        
        Rectangle[] Frames = new Rectangle[SpriteFrameCount];
        Rectangle destination;
        int stallframesCounter;
        int frameIndex;
        ITile owner;
        public DummyHeartSprite(ITile par) {
            
           
        }
        public void Update() { 
           
        }
        public void Draw() {
            
        }

    }
}
