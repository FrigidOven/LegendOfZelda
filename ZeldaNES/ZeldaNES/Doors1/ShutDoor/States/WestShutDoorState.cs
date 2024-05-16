using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.DoorSprites.ShutDoorSprites;

namespace ZeldaNES.Doors1.ShutDoor.States
{
    public class WestShutDoorState : IDoorState
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
        public WestShutDoorState(IDoor door)
        {
            Door = door;
            posX = GeneralConstants.WestDoorPosition.Item1;
            posY = GeneralConstants.WestDoorPosition.Item2;
            passable = false;
            sprite = new WestShutDoorSprite(door);
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
            return GeneralConstants.CardinalDirection.West;
        }
        public Type GetLinkingType()
        {
            return typeof(ShutDoor);
        }
        public void Update()
        {
            sprite.Update();
            debugSprite.Update();
        }
        public void Open()
        {
            Door.SetState(new WestOpenDoorState(Door));
            Door.Body().Hitbox.IsActive = true;
        }
        public void Close()
        {

        }
    }
}
