using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Doors1.ShutDoor.States
{
    public class SouthOpenDoorState : IDoorState
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
        public SouthOpenDoorState(IDoor door)
        {
            Door = door;
            posX = GeneralConstants.SouthDoorPosition.Item1;
            posY = GeneralConstants.SouthDoorPosition.Item2;
            passable = true;
            sprite = new SouthOpenDoorSprite(door);
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
            return GeneralConstants.CardinalDirection.South;
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

        }
        public void Close()
        {
            Door.SetState(new SouthShutDoorState(Door));
            Door.Body().Hitbox.IsActive = false;
        }
    }
}
