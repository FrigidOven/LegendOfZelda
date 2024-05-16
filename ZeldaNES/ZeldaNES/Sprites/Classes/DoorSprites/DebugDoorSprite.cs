using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Doors1;


namespace ZeldaNES.Sprites
{
    public class DebugDoorSprite
    {
        public int PosX;
        public int PosY;
        public IDoor owner;
        public DebugDoorSprite(IDoor owner) {
            this.owner = owner;
        }
        public void Draw()
        {
            TextureManager.TextureManager.Instance.SpriteBatch.DrawString(TextureManager.TextureManager.Instance.gameFont, owner.Index.ToString(), new Vector2(owner.PosX, owner.PosY), Color.Red);
        }
        public void Update() { 
        
        }
    }
}
