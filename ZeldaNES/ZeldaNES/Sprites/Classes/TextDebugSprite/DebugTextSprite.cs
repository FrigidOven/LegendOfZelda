using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZeldaNES.Sprites
{
    public class DebugTextSprite
    {
        public int PosX;
        public int PosY;
        public DebugTextSprite(int x, int y) {
            PosX = x;
            PosY = y;
        }
        public void Draw(string message)
        {
            TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont, message, new Vector2(PosX, PosY), Color.White);
        }
        public void Update() { 
        
        }
    }
}
