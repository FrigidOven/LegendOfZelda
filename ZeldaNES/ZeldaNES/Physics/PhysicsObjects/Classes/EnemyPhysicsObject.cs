using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Sprites.Classes.TileSprites;
using static System.Net.Mime.MediaTypeNames;

namespace ZeldaNES.Physics.PhysicsObjects.Classes
{
    public class EnemyPhysicsObject : IEnemyPhysicsObject
    {
        private int posX;
        private int posY;
        private int health;
        private int damage;
        private bool isTakingDamage;
        private IHitbox hitbox;

        public EnemyPhysicsObject(int posX, int posY, int maxHealth)
        {
            this.posX = posX;
            this.posY = posY;
            // temporary
            damage = 1;
            health = maxHealth;
            hitbox = new Hitbox(posX, posY, DungeonTileSpriteConstants.TileSpriteSize, true);
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
        public int Health
        {
            get => health;
            set
            {
                if ( value < health )
                {
                    isTakingDamage = true;
                }
                health = value;
            }
        }
        public int Damage
        {
            get => damage;
            set => damage = value;
        }
        public bool IsTakingDamage
        {
            get => isTakingDamage;
            set => isTakingDamage = value;
        }
        public IHitbox Hitbox
        {
            get => hitbox;
            set => hitbox = value;
        }
    }
}
