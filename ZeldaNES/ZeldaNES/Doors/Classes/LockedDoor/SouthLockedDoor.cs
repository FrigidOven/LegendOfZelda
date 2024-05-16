using Microsoft.Xna.Framework.Graphics;
using System;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.DoorSprites.LockedDoorSprites;

namespace ZeldaNES.Doors.Classes.LockedDoor
{
    public class SouthLockedDoor : IDoor
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


        public SouthLockedDoor()
        {
            body = new DoorPhysicsObject(posX, posY, false);

            //sprite = new SouthLockedDoorSprite(this);
           // debugSprite = new DebugDoorSprite(this);

            PosX = posX;
            PosY = posY;

        }
        public Type GetLinkingType()
        {

            return typeof(NorthLockedDoor);
        }
        public int GetIndex()
        {
            return Index;
        }
        public GeneralConstants.CardinalDirection GetCardinalPosition()
        {
            return cardinality;
        }
        public int GetPosX()
        {
            return PosX;
        }
        public int GetPosY()
        {
            return PosY;
        }
        public void SetPos(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void DrawDebug()
        {
            debugSprite.Draw();
        }
        public void Update()
        {
            sprite.Update();
        }
    }
}
