using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Physics.PhysicsObjects;

namespace ZeldaNES.Tiles.Classes
{
    public class BrickTile : ITile
    {
        private bool isSolid;
        private ISprite sprite;
        private ITilePhysicsObject body;

        public int PosX
        {
            get => body.PosX;
            set
            {
                body.PosX = value;
            }
        }
        public int PosY
        {
            get => body.PosY;
            set
            {
                body.PosY = value;
            }
        }

        public BrickTile(int posX, int posY)
        {
            this.isSolid = true;
            body = new TilePhysicsObject(posX, posY, this.isSolid);
            PosX = posX;
            PosY = posY;
            sprite = new BrickSprite(this);  
        }
        public BrickTile() {
            this.isSolid = true;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new BrickSprite(this);
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

        public void Update()
        {
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw();
        }

        public bool IsSolid()
        {
            return isSolid;
        }

        public int GetPosX()
        {
            return PosX;
        }

        public int GetPosY()
        {
            return PosY;
        }
    }
}
