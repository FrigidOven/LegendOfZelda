using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Doors1.ShutDoor.States;

namespace ZeldaNES.Doors1.ShutDoor
{
    public class ShutDoor : IDoor
    {
        private int index;
        private int posX;
        private int posY;

        private IDoorState State { get; set; }
        private IDoorPhysicsObject body;
        public IDoorState GetState()
        {
            return State;
        }
        public void SetState(IDoorState state)
        {
            State = state;
        }
        public int Index
        {
            get { return index; }
            set { index = value; }
        }
        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }
        public ShutDoor()
        {

        }
        private void Initialize()
        {
            if (posX == GeneralConstants.NorthDoorPosition.Item1 && posY == GeneralConstants.NorthDoorPosition.Item2)
            {
                State = new NorthShutDoorState(this);
            }
            else if (posX == GeneralConstants.SouthDoorPosition.Item1 && posY == GeneralConstants.SouthDoorPosition.Item2)
            {
                State = new SouthShutDoorState(this);
            }
            else if (posX == GeneralConstants.EastDoorPosition.Item1 && posY == GeneralConstants.EastDoorPosition.Item2)
            {
                State = new EastShutDoorState(this);
            }
            else // if (posX == GeneralConstants.WestDoorPosition.Item1 && posY == GeneralConstants.WestDoorPosition.Item2)
            {
                State = new WestShutDoorState(this);
            }

            body = new DoorPhysicsObject(State.PosX, State.PosY, State.Passable);
        }
        public IDoorPhysicsObject Body()
        {
            if(body == null)
            {
                Initialize();
            }

            return body;
        }
        public void Update()
        {
            if (body == null)
            {
                Initialize();
            }

            State.Update();
        }
        public void Draw()
        {
            if (body == null)
            {
                Initialize();
            }

            State.Draw();
        }
        public void DrawDebug()
        {
            if (body == null)
            {
                Initialize();
            }

            State.DrawDebug();
        }
        public GeneralConstants.CardinalDirection GetCardinalPosition()
        {
            if (body == null)
            {
                Initialize();
            }

            return State.GetCardinalPosition();
        }
        public int GetIndex()
        {
            if (body == null)
            {
                Initialize();
            }

            return Index;
        }
        public Type GetLinkingType()
        {
            if (body == null)
            {
                Initialize();
            }

            return State.GetLinkingType();
        }
        public void Open()
        {
            if (body == null)
            {
                Initialize();
            }

            State.Open();
        }
        public void Close()
        {
            if (body == null)
            {
                Initialize();
            }

            State.Close();
        }
    }
}
