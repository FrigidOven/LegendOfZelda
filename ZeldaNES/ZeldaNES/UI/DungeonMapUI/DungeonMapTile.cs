using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.UISprites;
using ZeldaNES.Sprites.UISprites;


namespace ZeldaNES.Tiles.Classes
{
    public class DungeonMapTile : ITile
    {
        private bool isSolid;
        public List<DungeonRoomMapTile> rooms = new List<DungeonRoomMapTile>();
        private ITilePhysicsObject body;
        public Dictionary<Area, (DungeonRoomMapTile, bool)> memory = new Dictionary<Area, (DungeonRoomMapTile, bool)>();
        bool isVisible = false;
        private int health = 6;
        public int PosX
        {
            get => body.PosX;
            set
            {
                int diffX = body.PosX - value;
                foreach (var room in rooms){
                    room.PosX -= diffX;
                }
                body.PosX = value;
                
            }
        }
        public int PosY
        {
            get => body.PosY;
            set
            {
                int diffY = body.PosY - value;
                foreach (var room in rooms)
                {
                    room.PosY -= diffY;
                }
                body.PosY = value;
            }
        }
        public void setVisible(bool visible)
        {
            isVisible = visible;
        }
        public DungeonMapTile(int posX, int posY)
        {
            body = new TilePhysicsObject(posX, posY, this.isSolid);

            PosX = posX;
            PosY = posY;
        }
        
        public DungeonMapTile() {
            this.isSolid = false;
            body = new TilePhysicsObject(0, 0, this.isSolid);
         
        }
      
        public ITilePhysicsObject Body()
        {
            return body;
        }
        public void Update()
        {
            foreach (var room in rooms)
            {
                room.Update();
            }
        }
        public void Draw() {
            if (isVisible)
            {
                foreach (var room in rooms)
                {
                    room.Draw();
                }
            }
        }

        public bool IsSolid()
        {
            return isSolid;
        }
    }
}
