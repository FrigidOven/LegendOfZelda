using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.UISprites;


namespace ZeldaNES.Tiles.Classes
{
    public class DungeonRoomMapTile : ITile
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

        public DungeonRoomMapTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);

            PosX = posX;
            PosY = posY;
            sprite = new DungeonRoomMapSprite(this);
        }
        public DungeonRoomMapTile() {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
            sprite = new DungeonRoomMapSprite(this);

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

        public bool IsSolid()
        {
            return isSolid;
        }
    }
}
