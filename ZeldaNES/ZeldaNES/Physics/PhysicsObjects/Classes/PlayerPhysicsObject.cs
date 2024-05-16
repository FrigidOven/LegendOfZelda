using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Players.Link;

namespace ZeldaNES.Physics.PhysicsObjects.Classes
{
    public class PlayerPhysicsObject : IPlayerPhysicsObject
    {
        private int posX;
        private int posY;
        private int health;
        private int damage;
        private bool isTakingDamage;
        private IHitbox playerHitbox;
        private IHitbox swordHitbox;

        public PlayerPhysicsObject()
        {
            posX = PlayerConstants.LinkStartX;
            posY = PlayerConstants.LinkStartY;
            health = PlayerConstants.LinkHealth;
            isTakingDamage = false;
            damage = 1;
            playerHitbox = new Hitbox(posX,
                                      posY,
                                      PlayerConstants.LinkHitboxXOffset,
                                      PlayerConstants.LinkHitboxYOffset,
                                      PlayerConstants.LinkHitboxWidth,
                                      PlayerConstants.LinkHitboxHeight,
                                      false);
            swordHitbox = new Hitbox(posX,
                                     posY,
                                     PlayerConstants.LinkDownSwordHitboxXOffset,
                                     PlayerConstants.LinkDownSwordHitboxYOffset,
                                     PlayerConstants.LinkDownSwordHitboxWidth,
                                     PlayerConstants.LinkDownSwordHitboxHeight,
                                     false);
        }

        public int PosX 
        {
            get => posX;
            set
            {
                posX = value;
                playerHitbox.PosX = value;
                swordHitbox.PosX = value;
            }
        }
        public int PosY
        {
            get => posY;
            set
            {
                posY = value;
                playerHitbox.PosY = value;
                swordHitbox.PosY = value;
            }
        }
        public int Health
        {
            get => health;
            set
            {
                if(value < health)
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
        public IHitbox PlayerHitbox
        {
            get => playerHitbox;
            set => playerHitbox = value;
        }
        public IHitbox SwordHitbox
        {
            get => swordHitbox;
            set => swordHitbox = value;
        }
    }
}
