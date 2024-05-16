using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.DoorSprites.OpenDoorSprites;

namespace ZeldaNES.Doors1.LockedDoor.States
{
    public class EastOpenDoorState : IDoorState
    {
        private ISprite sprite;
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
        public EastOpenDoorState(IDoor door)
        {
            Door = door;
            posX = GeneralConstants.EastDoorPosition.Item1;
            posY = GeneralConstants.EastDoorPosition.Item2;
            passable = true;
            sprite = new EastOpenDoorSprite(door);
            debugSprite = new DebugDoorSprite(door);
        }

        public void Draw()
        {
            sprite.Draw();
        }

        public void DrawDebug()
        {
            debugSprite.Draw();
        }

        public GeneralConstants.CardinalDirection GetCardinalPosition()
        {
            return GeneralConstants.CardinalDirection.East;
        }
        public Type GetLinkingType()
        {
            return typeof(LockedDoor);
        }
        public void Update()
        {
            sprite.Update();
            debugSprite.Update();
        }
        public void Open()
        {

        }
        public void Close()
        {
            Door.SetState(new EastLockedDoorState(Door));
            Door.Body().Hitbox.IsActive = false;
        }
    }
}
