using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites;

namespace ZeldaNES.Tiles.Classes
{
    internal class BlackBackgroundTile : ITile
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

        public BlackBackgroundTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);

            PosX = posX;
            PosY = posY;
            sprite = new BlackBackgroundSprite(this);
        }
        public BlackBackgroundTile()
        {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new BlackBackgroundSprite(this);
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
