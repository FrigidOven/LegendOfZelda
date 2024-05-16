using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.DoorSprites.ShutDoorSprites;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Doors.Classes.ShutDoor
{
    public class SouthShutDoor: IDoor
    {
        private ISprite sprite;
        private int posX = GeneralConstants.SouthDoorPosition.Item1;
        private int posY = GeneralConstants.SouthDoorPosition.Item2;
        private DebugDoorSprite debugSprite;

        private IDoorPhysicsObject body;

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
        public IDoorPhysicsObject Body()
        {
            return body;
        }
        public int Index { get; set; }
        private GeneralConstants.CardinalDirection cardinality = GeneralConstants.CardinalDirection.South;


        public SouthShutDoor() {
            body = new DoorPhysicsObject(posX, posY, false);

            //sprite = new SouthShutDoorSprite(this);
            //debugSprite = new DebugDoorSprite(this);

            PosX = posX;
            PosY = posY;

        }
        public Type GetLinkingType()
        {

            return typeof(NorthShutDoor);
        }
        public int GetIndex() {
            return Index;
        }
        public GeneralConstants.CardinalDirection GetCardinalPosition() {
            return cardinality;
        }
        public int GetPosX() {
            return PosX;
        }
        public int GetPosY() {
            return PosY;
        }
        public void SetPos(int x, int y) {
            PosX = x;
            PosY = y;
        }
        public void Draw() {
            sprite.Draw();
        }
        public void DrawDebug()
        {
            debugSprite.Draw();
        }
        public void Update() { 
            sprite.Update(); 
        }
    }
}
