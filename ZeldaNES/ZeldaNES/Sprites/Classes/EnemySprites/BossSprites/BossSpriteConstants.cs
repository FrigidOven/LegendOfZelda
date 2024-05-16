using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Sprites.Classes.EnemySprites.BossSprites
{
    public static class BossSpriteConstants
    {
        public static readonly int SpriteSize = 32;
        public static readonly int SpriteScale = 3;

        public static readonly int UpFacingSpritesIndex = 0;
        public static readonly int DownFacingSpritesIndex = SpriteSize;
        public static readonly int LeftFacingSpritesIndex = SpriteSize * 2;
        public static readonly int RightFacingSpritesIndex = SpriteSize * 3;

        public static readonly int BossWalkingSpritesIndex = 0;
        public static readonly int BossWalkingSpritesFrameCount = 2;
        public static readonly int BossWalkingSpritesStallFrameCount = 10;

        public static readonly int BossAttackingSpritesIndex = BossWalkingSpritesIndex + SpriteSize * BossWalkingSpritesFrameCount;
        public static readonly int BossAttackingSpritesFrameCount = 2;
        public static readonly int BossAttackingSpritesStallFrameCount = 10;

        public static readonly int DodongoWalkingSpritesIndex = BossAttackingSpritesIndex + SpriteSize * BossAttackingSpritesFrameCount;
        public static readonly int DodongoWalkingSpritesFrameCount = 2;
        public static readonly int DodongoWalkingSpritesStallFrameCount = 10;

        public static readonly int DodongoEatingBombSpritesIndex = DodongoWalkingSpritesIndex + SpriteSize * DodongoWalkingSpritesFrameCount;
        public static readonly int DodongoEatingBombSpritesFrameCount = 1;
        public static readonly int DodongoEatingBombSpritesStallFrameCount = 10;
    }
}
