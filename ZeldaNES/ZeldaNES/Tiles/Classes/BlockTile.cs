using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Tiles.Classes
{
    public class BlockTile : ITile
    {
        private bool isSolid;
        private ISprite sprite;
        private ITilePhysicsObject body;

        public int PosX { get => body.PosX; set => body.PosX = value; }
        public int PosY { get => body.PosY; set => body.PosY = value; }
        

        public BlockTile() {
            this.isSolid = true;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new BlockSprite(this);

        }
        public BlockTile(int x, int y)
        {
            this.isSolid = true;
            body = new TilePhysicsObject(x, y, this.isSolid);
            PosX = x;
            PosY = y;
            sprite = new BlockSprite(this);

        }
        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        public ITilePhysicsObject Body()
        {
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
