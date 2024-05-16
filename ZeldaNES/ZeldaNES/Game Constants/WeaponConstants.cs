using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.LinkWeaponSprites;

namespace ZeldaNES.Game_Constants
{
    public static class WeaponConstants
    {
        public static readonly int ProjectileSpeed = 6;
        public static readonly int WeakProjectileTerminationDistance = 200;
        public static readonly int StrongProjectileTerminationDistance = 2 * WeakProjectileTerminationDistance;


        public static readonly int WeaponSpawnDistance = WeaponSpriteConstants.SpriteSize * 3;

        public static readonly int WoodenArrowSpeed = ProjectileSpeed;
        public static readonly int WoodenArrowTerminationDistance = WeakProjectileTerminationDistance;

        public static readonly int MetalArrowSpeed = ProjectileSpeed;
        public static readonly int MetalArrowTerminationDistance = StrongProjectileTerminationDistance;

        public static readonly int WoodenBoomerangSpeed = ProjectileSpeed;
        public static readonly int WoodenBoomerangTerminationDistance = WeakProjectileTerminationDistance;

        public static readonly int MetalBoomerangSpeed = ProjectileSpeed;
        public static readonly int MetalBoomerangTerminationDistance = StrongProjectileTerminationDistance;

        // bomb shouldn't move, unless we want to change that later.
        public static readonly int BombSpeed = 0;
        public static readonly int BombTerminationDistance = WeakProjectileTerminationDistance;
        public static readonly int BombTickCount = 100;

        public static readonly int FireSpeed = ProjectileSpeed;
        public static readonly int FireTerminationDistance = WeakProjectileTerminationDistance;
        public static readonly int FireLingerDuration = 100;

        public static readonly int EnergyBallSpeed = ProjectileSpeed;
        public static readonly int EnergyBallTerminationDistance = StrongProjectileTerminationDistance;



        public static readonly int BombHitboxSize = 16 * 3;



        // damage not yet implemented...
        //public static readonly int WoodenArrowDamage = 1;
        //public static readonly int MetalArrowDamage = 1;

        //public static readonly int WoodenBoomerangDamage = 1;
        //public static readonly int MetalBoomerangDamage = 1;

        //public static readonly int BombDamage = 1;
        //public static readonly int FireDamage = 1;

        //public static readonly int EnergyBallDamage = 1;


        public static readonly int ClockTickCount = 100;

    }
}
