﻿using Microsoft.Xna.Framework.Graphics;
using System;
using ZeldaNES.Doors.Classes.OpenDoor;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.DoorSprites.HiddenDoorSprites;

namespace ZeldaNES.Doors.Classes.HiddenDoor
{
    public class NorthHiddenDoor : IDoor
    {
        private ISprite sprite;
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
        private GeneralConstants.CardinalDirection cardinality = GeneralConstants.CardinalDirection.North;


        public NorthHiddenDoor()
        {
            body = new DoorPhysicsObject(posX, posY, false);
            //sprite = new NorthHiddenDoorSprite(this);
            //debugSprite = new DebugDoorSprite(this);
            PosX = posX;
            PosY = posY;
            

        }
        public Type GetLinkingType()
        {

            return typeof(SouthHiddenDoor);
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
