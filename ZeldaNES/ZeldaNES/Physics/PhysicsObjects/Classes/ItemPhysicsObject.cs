using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.Hitboxes;


namespace ZeldaNES.Physics.PhysicsObjects.Classes
{
    public class ItemPhysicsObject : IItemPhysicsObject
    {
        private int posX;
        private int posY;
        private IHitbox hitbox;

        public ItemPhysicsObject(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;

            hitbox = new Hitbox(posX, posY, 16, true);
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
