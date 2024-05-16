using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Tiles.Classes
{
    public class FirstDungeonBackgroundTile : ITile
    {
        private bool isSolid;
        private ISprite sprite;
        private ITilePhysicsObject body;

        public int PosX { get => body.PosX; set => body.PosX = value; }
        public int PosY { get => body.PosY; set => body.PosY = value; }

        public FirstDungeonBackgroundTile() 
        {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new FirstDungeonBackgroundSprite(this);

        }
        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        public void Update() {
            sprite.Update();
        }

        public void Draw() {
            sprite.Draw();
        }
        public ITilePhysicsObject Body()
        {
            return body;
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
