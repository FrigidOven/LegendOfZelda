using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Game_Constants
{
    public static class PlayerConstants
    {
        public static readonly int LinkStartX = 400;
        public static readonly int LinkStartY = 50;

        public static readonly int LinkWalkingSpeed = GeneralConstants.ImageScale;
        public static readonly int LinkDashingSpeed = GeneralConstants.ImageScale * 3;

        public static readonly int LinkHealthCapacity = 2;
        public static readonly int LinkHealth= 2;
        public static readonly int DamageTicks = 80;
        public static readonly int LinkDamage = 1;

        public static readonly int LinkHitboxWidth = 10;
        public static readonly int LinkHitboxHeight = 8;
        public static readonly int LinkHitboxXOffset = 2 * GeneralConstants.ImageScale;
        public static readonly int LinkHitboxYOffset = 4 * GeneralConstants.ImageScale;


        public static readonly int LinkUpSwordHitboxWidth = 3;
        public static readonly int LinkUpSwordHitboxHeight = 16;
        public static readonly int LinkUpSwordHitboxXOffset = -(2 * GeneralConstants.ImageScale);
        public static readonly int LinkUpSwordHitboxYOffset = -(12 * GeneralConstants.ImageScale);

        public static readonly int LinkDownSwordHitboxWidth = 3;
        public static readonly int LinkDownSwordHitboxHeight = 16;
        public static readonly int LinkDownSwordHitboxXOffset = 0 * GeneralConstants.ImageScale;
        public static readonly int LinkDownSwordHitboxYOffset = 11 * GeneralConstants.ImageScale;

        public static readonly int LinkLeftSwordHitboxWidth = 16;
        public static readonly int LinkLeftSwordHitboxHeight = 3;
        public static readonly int LinkLeftSwordHitboxXOffset = -(11 * GeneralConstants.ImageScale);
        public static readonly int LinkLeftSwordHitboxYOffset = 1 * GeneralConstants.ImageScale;

        public static readonly int LinkRightSwordHitboxWidth = 16;
        public static readonly int LinkRightSwordHitboxHeight = 3;
        public static readonly int LinkRightSwordHitboxXOffset = 11 * GeneralConstants.ImageScale;
        public static readonly int LinkRightSwordHitboxYOffset = 1 * GeneralConstants.ImageScale;


        public static readonly int FreezeTime = 60;

    }
}
