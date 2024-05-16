using Microsoft.Xna.Framework.Graphics;
using System;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.DoorSprites.OpenDoorSprites;

namespace ZeldaNES.Doors.Classes.OpenDoor
{
    public class NorthOpenDoor : IDoor
    {
        private int posX = GeneralConstants.NorthDoorPosition.Item1;
        private int posY = GeneralConstants.NorthDoorPosition.Item2;
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


        private ISprite sprite;
        public int GetIndex() {
            return Index;
        }
        public GeneralConstants.CardinalDirection GetCardinalPosition() {
            return GeneralConstants.CardinalDirection.North;
        }
        public NorthOpenDoor(int posX, int posY)
        {
            body = new DoorPhysicsObject(posX, posY, false);

            //sprite = new NorthOpenDoorSprite(this);
            //debugSprite = new DebugDoorSprite(this);

            PosX = posX;
            PosY = posY;
        }
        public NorthOpenDoor()
        {
            body = new DoorPhysicsObject(posX, posY, false);
            //sprite = new NorthOpenDoorSprite(this);
            //debugSprite = new DebugDoorSprite(this);


        }
        public Type GetLinkingType()
        {

            return typeof(SouthOpenDoor);
        }
        public void SetPos(int x, int y)
        {
            posX = x;
            posY = y;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw();
        }
        public void DrawDebug() { 
            debugSprite.Draw();
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
