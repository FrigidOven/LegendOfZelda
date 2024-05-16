using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Physics.PhysicsObjects.Classes;

namespace ZeldaNES.Tiles.Classes
{
    public class WhiteStairTile : ITile
    {
        private bool isSolid;
        private ISprite sprite;
        private ITilePhysicsObject body;

        public int PosX { get => body.PosX; set => body.PosX = value; }
        public int PosY { get => body.PosY; set => body.PosY = value; }
     
        public WhiteStairTile() 
        {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new WhiteStairSprite(this);

        }
        public WhiteStairTile(int x, int y)
        {
            body = new TilePhysicsObject(x, y, this.isSolid);
            PosX = x;
            PosY = y;
            this.isSolid = false;
            sprite = new WhiteStairSprite(this);
        }
        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        public ITilePhysicsObject Body() {
            return body;
        } 
        public void Update() {
            sprite.Update();
        }

        public void Draw() {
            sprite.Draw();
        }

        public bool IsSolid() {
            return isSolid;
        }

        public int GetPosX() {
            return PosX;
        }
        
        public int GetPosY()
        {
            return PosY;
        }
    }
}
