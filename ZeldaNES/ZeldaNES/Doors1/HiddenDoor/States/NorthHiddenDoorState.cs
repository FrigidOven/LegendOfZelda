using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;

namespace ZeldaNES.Doors1.HiddenDoor.States
{
    public class NorthHiddenDoorState : IDoorState
    {
        private DebugDoorSprite debugSprite;

        private int posX;
        private int posY;
        private bool passable;

        public IDoor Door { get; set; }
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
        public bool Passable
        {
            get { return passable; }
            set { passable = value; }
        }
        public NorthHiddenDoorState(IDoor door)
        {
            Door = door;
            posX = GeneralConstants.NorthDoorPosition.Item1;
            posY = GeneralConstants.NorthDoorPosition.Item2;
            passable = false;
            debugSprite = new DebugDoorSprite(door);
        }

        public void Draw()
        {

        }

        public void DrawDebug()
        {
            debugSprite.Draw();
        }

        public GeneralConstants.CardinalDirection GetCardinalPosition()
        {
            return GeneralConstants.CardinalDirection.North;
        }
        public Type GetLinkingType()
        {
            return typeof(HiddenDoor);
        }
        public void Update()
        {
            debugSprite.Update();
        }
        public void Open()
        {
            Door.SetState(new NorthExplodedDoorState(Door));
            Door.Body().Hitbox.IsActive = true;
        }
        public void Close()
        {

        }
    }
}
