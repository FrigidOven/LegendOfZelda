using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;


namespace ZeldaNES.Tiles.Classes
{
    public class DirtTile : ITile
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
        public ITilePhysicsObject Body()
        {
            return body;
        }

        public DirtTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);
            PosX = posX;
            PosY = posY;
            sprite = new DirtSprite(this);

          
        }
        public DirtTile() 
        {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new DirtSprite(this);
         

        }
        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
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
