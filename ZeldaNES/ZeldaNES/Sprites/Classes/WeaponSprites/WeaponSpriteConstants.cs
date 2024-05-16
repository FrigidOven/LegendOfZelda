using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Sprites.Classes.LinkWeaponSprites
{
    public static class WeaponSpriteConstants
    {
        public static readonly int SpriteSize = 16;

        public static readonly int UpFacingSpritesIndex = 0;
        public static readonly int DownFacingSpritesIndex = SpriteSize;
        public static readonly int LeftFacingSpritesIndex = SpriteSize * 2;
        public static readonly int RightFacingSpritesIndex = SpriteSize * 3;
        public static readonly int TerminationSpritesIndex = SpriteSize * 4;

        public static readonly int WoodenArrowSpritesIndex = 0;
        public static readonly int WoodenArrowSpritesFrameCount = 1;
        public static readonly int WoodenArrowSpritesStallFrameCount = 0;

        public static readonly int MetalArrowSpritesIndex = WoodenArrowSpritesIndex + SpriteSize * WoodenArrowSpritesFrameCount;
        public static readonly int MetalArrowSpritesFrameCount = 1;
        public static readonly int MetalArrowSpritesStallFrameCount = 0;

        public static readonly int WoodenBoomerangSpritesIndex = MetalArrowSpritesIndex + SpriteSize * MetalArrowSpritesFrameCount;
        public static readonly int WoodenBoomerangSpritesFrameCount = 8;
        public static readonly int WoodenBoomerangSpritesStallFrameCount = 2;

        public static readonly int MetalBoomerangSpritesIndex = WoodenBoomerangSpritesIndex + SpriteSize * WoodenBoomerangSpritesFrameCount;
        public static readonly int MetalBoomerangSpritesFrameCount = 8;
        public static readonly int MetalBoomerangSpritesStallFrameCount = 2;

        public static readonly int BombSpritesIndex = MetalBoomerangSpritesIndex + SpriteSize * MetalBoomerangSpritesFrameCount;
        public static readonly int BombSpritesFrameCount = 2;
        public static readonly int BombSpritesStallFrameCount = 8;

        public static readonly int FireSpritesIndex = BombSpritesIndex + SpriteSize * BombSpritesFrameCount;
        public static readonly int FireSpritesFrameCount = 2;
        public static readonly int FireSpritesStallFrameCount = 8;

        public static readonly int EnergyBallSpritesIndex = FireSpritesIndex + SpriteSize * FireSpritesFrameCount;
        public static readonly int EnergyBallSpritesFrameCount = 4;
        public static readonly int EnergyBallSpritesStallFrameCount = 2;

        public static readonly int ArrowTerminationSpritesIndex = 0;
        public static readonly int ArrowTerminationSpritesFrameCount = 1;
        public static readonly int ArrowTerminationSpritesStallFrameCount = 4;

        public static readonly int BombTerminationSpritesIndex = ArrowTerminationSpritesIndex + SpriteSize * ArrowTerminationSpritesFrameCount;
        public static readonly int BombTerminationSpritesFrameCount = 3;
        public static readonly int BombTerminationSpritesStallFrameCount = 4;
    }
}
