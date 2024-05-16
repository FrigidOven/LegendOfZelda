using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites
{
    public static class DungeonEnemySpriteConstants
    {
        public static readonly int SpriteSize = 32;
        public static readonly int SpriteScale = 3;

        public static readonly int UpFacingSpritesIndex = 0;
        public static readonly int DownFacingSpritesIndex = SpriteSize;
        public static readonly int LeftFacingSpritesIndex = SpriteSize * 2;
        public static readonly int RightFacingSpritesIndex = SpriteSize * 3;

        public static readonly int OldManSpriteIndex = 0;

        public static readonly int StalfoSpritesIndex = 0;
        public static readonly int StalfoSpritesFrameCount = 2;
        public static readonly int StalfoSpritesStallFrameCount = 10;

        public static readonly int GelSpritesIndex = StalfoSpritesIndex + SpriteSize * StalfoSpritesFrameCount;
        public static readonly int GelSpritesFrameCount = 2;
        public static readonly int GelSpritesStallFrameCount = 2;

        public static readonly int KeeseSpritesIndex = GelSpritesIndex + SpriteSize * GelSpritesFrameCount;
        public static readonly int KeeseSpritesFrameCount = 2;
        public static readonly int KeeseSpritesStallFrameCount = 10;

        public static readonly int RopeSpriteIndex = KeeseSpritesIndex;

        public static readonly int GoriyaSpritesIndex = KeeseSpritesIndex + SpriteSize * KeeseSpritesFrameCount;
        public static readonly int GoriyaSpritesFrameCount = 2;
        public static readonly int GoriyaSpritesStallFrameCount = 10;

        public static readonly int GoriyaAttackingSpritesIndex = GoriyaSpritesIndex + SpriteSize * GoriyaSpritesFrameCount;
        public static readonly int GoriyaAttackingSpritesFrameCount = 1;
        public static readonly int GoriyaAttackingSpritesStallFrameCount = 2;

        public static readonly int BladeTrapSpritesIndex = GoriyaAttackingSpritesIndex + SpriteSize * GoriyaAttackingSpritesFrameCount;
        public static readonly int BladeTrapSpritesFrameCount = 1;
        public static readonly int BladeTrapSpritesStallFrameCount = 2;

        public static readonly int WallMasterWalkingSpritesIndex = BladeTrapSpritesIndex + SpriteSize * BladeTrapSpritesFrameCount;
        public static readonly int WallMasterWalkingSpritesFrameCount = 2;
        public static readonly int WallMasterWalkingSpritesStallFrameCount = 2;

        public static readonly int WallMasterAttackingSpritesIndex = WallMasterWalkingSpritesIndex + SpriteSize * WallMasterWalkingSpritesFrameCount;
        public static readonly int WallMasterAttackingSpritesFrameCount = 1;
        public static readonly int WallMasterAttackingSpritesStallFrameCount = 0;

        public static readonly int AquamentusWalkingSpritesIndex = WallMasterAttackingSpritesIndex + SpriteSize * WallMasterAttackingSpritesFrameCount;
        public static readonly int AquamentusWalkingSpritesFrameCount = 2;
        public static readonly int AquamentusWalkingSpritesStallFrameCount = 10;

        public static readonly int AquamentusAttackingSpritesIndex = AquamentusWalkingSpritesIndex + SpriteSize * AquamentusWalkingSpritesFrameCount;
        public static readonly int AquamentusAttackingSpritesFrameCount = 2;
        public static readonly int AquamentusAttackingSpritesStallFrameCount = 10;

        public static readonly int DodongoWalkingSpritesIndex = AquamentusAttackingSpritesIndex + SpriteSize * AquamentusAttackingSpritesFrameCount;
        public static readonly int DodongoWalkingSpritesFrameCount = 2;
        public static readonly int DodongoWalkingSpritesStallFrameCount = 10;

        public static readonly int DodongoEatingBombSpritesIndex = DodongoWalkingSpritesIndex + SpriteSize * DodongoWalkingSpritesFrameCount;
        public static readonly int DodongoEatingBombSpritesFrameCount = 1;
        public static readonly int DodongoEatingBombSpritesStallFrameCount = 10;
    }
}
