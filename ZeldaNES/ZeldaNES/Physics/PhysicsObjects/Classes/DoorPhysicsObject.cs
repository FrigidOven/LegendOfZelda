using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.Hitboxes;

namespace ZeldaNES.Physics.PhysicsObjects.Classes
{
    public class DoorPhysicsObject : IDoorPhysicsObject
    {
        private int posX;
        private int posY;
        private IHitbox hitbox;
        public bool IsBeingTouched { get; set; }
        public DoorPhysicsObject(int posX, int posY, bool passable)
        {
            this.posX = posX;
            this.posY = posY;
            hitbox = new Hitbox(posX, posY, 32, passable);
        }

        public int PosX
        {
            get => posX;
            set
            {
                posX = value;
                hitbox.PosX = value;
                hitbox.PosX = value;
            }
        }
        public int PosY
        {
            get => posY;
            set
            {
                posY = value;
                hitbox.PosY = value;
                hitbox.PosY = value;
            }
        }
        public IHitbox Hitbox
        {
            get => hitbox;
            set => hitbox = value;
        }
    }
}
