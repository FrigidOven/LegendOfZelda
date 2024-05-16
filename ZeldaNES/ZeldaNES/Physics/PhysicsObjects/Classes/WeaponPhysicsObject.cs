using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.LinkWeaponSprites;

namespace ZeldaNES.Physics.PhysicsObjects.Classes
{
    public class WeaponPhysicsObject : IWeaponPhysicsObject
    {
        private int posX;
        private int posY;
        private int damage;
        private IHitbox hitbox;

        public WeaponPhysicsObject(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;

            int width = 8;
            int height = 8;
            damage = 1;
            hitbox = new Hitbox(posX, posY, 0, 0, width, height, true);
        }

        public WeaponPhysicsObject(int posX, int posY, int size, bool isActive)
        {
            this.posX = posX;
            this.posY = posY;

            hitbox = new Hitbox(posX, posY, 0, 0, size, size, isActive);
            damage = 3;
        }
        public WeaponPhysicsObject(int posX, int posY, int size)
        {
            this.posX = posX;
            this.posY = posY;

            hitbox = new Hitbox(posX, posY, 0, 0, size, size, true);
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
        public int Damage
        {
            get => damage;
            set => damage = value;
        }
        public IHitbox Hitbox
        {
            get => hitbox;
            set => hitbox = value;
        }
    }
}
