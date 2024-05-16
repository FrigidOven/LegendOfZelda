using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.ItemSprites;
using ZeldaNES.SoundManager;

namespace ZeldaNES.Tiles.Classes
{
    public class PushableBlockTile : ITile
    {
        private bool isSolid;
        private ISprite sprite;
        private ITilePhysicsObject body;
        public int pushCount = 0;
        public bool hasTrigger = false;

        public int PosX { get => body.PosX; set => body.PosX = value; }
        public int PosY { get => body.PosY; set => body.PosY = value; }


        public PushableBlockTile()
        {
            this.isSolid = true;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new PushableBlockSprite(this);

        }
        public PushableBlockTile(int x, int y)
        {
            this.isSolid = true;
            body = new TilePhysicsObject(x, y, this.isSolid);
            PosX = x;
            PosY = y;
            sprite = new PushableBlockSprite(this);

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
        public void Push()
        {
            if (pushCount > 19)
            {
                this.PosY += ItemSpriteConstants.SpriteSize * ItemSpriteConstants.SpriteScale;
                SoundManager.SoundManager.Instance.Secret.Play();
            }
            
        }
    }
}
