using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Sprites.Classes.ItemSprites
{
    public static class ItemSpriteConstants
    {
        /*
         * We do not have to make sprites for all these yet, just the ones for sprint 2.
         * Some will have frames associated because they are animated, if they are static they won't.
         */

        public static readonly int SpriteSize = 16;
        public static readonly int SpriteScale = 3;
        public static readonly int NumberOfItems = 35;

        private static readonly int defaultItemStallFrameCount = 10;

        public static readonly int HeartSpriteIndex = 0;
        public static readonly int HeartSpriteFrameCount = 2;
        public static readonly int HeartSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int HalfHeartSpriteIndex = HeartSpriteIndex + SpriteSize * HeartSpriteFrameCount;
        public static readonly int HalfHeartSpriteFrameCount = 2;
        public static readonly int HalfHeartSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int HeartContainerSpriteIndex = HalfHeartSpriteIndex + SpriteSize * HalfHeartSpriteFrameCount;
        public static readonly int HeartContainerSpriteFrameCount = 1;
        public static readonly int HeartContainerSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int FairySpriteIndex = HeartContainerSpriteIndex + SpriteSize;
        public static readonly int FairySpriteFrameCount = 2;
        public static readonly int FairySpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int ClockSpriteIndex = FairySpriteIndex + SpriteSize * FairySpriteFrameCount;
        public static readonly int ClockSpriteFrameCount = 1;
        public static readonly int ClockSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int RupeeSpriteIndex = ClockSpriteIndex + SpriteSize;
        public static readonly int RupeeSpriteFrameCount = 2;
        public static readonly int RupeeSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int RedPotionSpriteIndex = RupeeSpriteIndex + SpriteSize * RupeeSpriteFrameCount;
        public static readonly int RedPotionSpriteFrameCount = 1;
        public static readonly int RedPotionSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int BluePotionSpriteIndex = RedPotionSpriteIndex + SpriteSize;
        public static readonly int BluePotionSpriteFrameCount = 1;
        public static readonly int BluePotionSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MapSpriteIndex = BluePotionSpriteIndex + SpriteSize;
        public static readonly int MapSpriteFrameCount = 1;
        public static readonly int MapSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int LetterSpriteIndex = MapSpriteIndex + SpriteSize;
        public static readonly int LetterSpriteFrameCount = 1;
        public static readonly int LetterSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MeatSpriteIndex = LetterSpriteIndex + SpriteSize;
        public static readonly int MeatSpriteFrameCount = 1;
        public static readonly int MeatSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int WoodenSwordSpriteIndex = MeatSpriteIndex + SpriteSize;
        public static readonly int WoodenSwordSpriteFrameCount = 1;
        public static readonly int WoodenSwordSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MetalSwordSpriteIndex = WoodenSwordSpriteIndex + SpriteSize;
        public static readonly int MetalSwordSpriteFrameCount = 1;
        public static readonly int MetalSwordSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MagicalSwordSpriteIndex = MetalSwordSpriteIndex + SpriteSize;
        public static readonly int MagicalSwordSpriteFrameCount = 1;
        public static readonly int MagicalSwordSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MagicalShieldSpriteIndex = MagicalSwordSpriteIndex + SpriteSize;
        public static readonly int MagicalShieldSpriteFrameCount = 1;
        public static readonly int MagicalShieldSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int WoodenBoomerangSpriteIndex = MagicalShieldSpriteIndex + SpriteSize;
        public static readonly int WoodenBoomerangSpriteFrameCount = 1;
        public static readonly int WoodenBoomerangSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MetalBoomerangSpriteIndex = WoodenBoomerangSpriteIndex + SpriteSize;
        public static readonly int MetalBoomerangSpriteFrameCount = 1;
        public static readonly int MetalBoomerangSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int WoodenArrowSpriteIndex = MetalBoomerangSpriteIndex + SpriteSize;
        public static readonly int WoodenArrowSpriteFrameCount = 1;
        public static readonly int WoodenArrowSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MetalArrowSpriteIndex = WoodenArrowSpriteIndex + SpriteSize;
        public static readonly int MetalArrowSpriteFrameCount = 1;
        public static readonly int MetalArrowSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int BombSpriteIndex = MetalArrowSpriteIndex + SpriteSize;
        public static readonly int BombSpriteFrameCount = 1;
        public static readonly int BombSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int BowSpriteIndex = BombSpriteIndex + SpriteSize;
        public static readonly int BowSpriteFrameCount = 1;
        public static readonly int BowSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int RedCandleSpriteIndex = BowSpriteIndex + SpriteSize;
        public static readonly int RedCandleSpriteFrameCount = 1;
        public static readonly int RedCandleSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int BlueCandleSpriteIndex = RedCandleSpriteIndex + SpriteSize;
        public static readonly int BlueCandleSpriteFrameCount = 1;
        public static readonly int BlueCandleSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int RedRingSpriteIndex = BlueCandleSpriteIndex + SpriteSize;
        public static readonly int RedRingSpriteFrameCount = 1;
        public static readonly int RedRingSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int BlueRingSpriteIndex = RedRingSpriteIndex + SpriteSize;
        public static readonly int BlueRingSpriteFrameCount = 1;
        public static readonly int BlueRingSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int PowerBraceletSpriteIndex = BlueRingSpriteIndex + SpriteSize;
        public static readonly int PowerBraceletSpriteFrameCount = 1;
        public static readonly int PowerBraceletSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int RecorderSpriteIndex = PowerBraceletSpriteIndex + SpriteSize;
        public static readonly int RecorderSpriteFrameCount = 1;
        public static readonly int RecorderSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int RaftSpriteIndex = RecorderSpriteIndex + SpriteSize;
        public static readonly int RaftSpriteFrameCount = 1;
        public static readonly int RaftSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int StepladderSpriteIndex = RaftSpriteIndex + SpriteSize;
        public static readonly int StepladderSpriteFrameCount = 1;
        public static readonly int StepladderSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MagicalRodSpriteIndex = StepladderSpriteIndex + SpriteSize;
        public static readonly int MagicalRodSpriteFrameCount = 1;
        public static readonly int MagicalRodSpriteStallFrameCount = defaultItemStallFrameCount;


        public static readonly int BookOfMagicSpriteIndex = MagicalRodSpriteIndex + SpriteSize;
        public static readonly int BookOfMagicSpriteFrameCount = 1;
        public static readonly int BookOfMagicSpriteStallFrameCount = defaultItemStallFrameCount;


        public static readonly int KeySpriteIndex = BookOfMagicSpriteIndex + SpriteSize;
        public static readonly int KeySpriteFrameCount = 1;
        public static readonly int KeySpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int MagicalKeySpriteIndex = KeySpriteIndex + SpriteSize;
        public static readonly int MagicalKeySpriteFrameCount = 1;
        public static readonly int MagicalKeySpriteStallFrameCount = defaultItemStallFrameCount;


        public static readonly int CompassSpriteIndex = MagicalKeySpriteIndex + SpriteSize;
        public static readonly int CompassSpriteFrameCount = 1;
        public static readonly int CompassSpriteStallFrameCount = defaultItemStallFrameCount;

        public static readonly int TriforceSpriteIndex = CompassSpriteIndex + SpriteSize;
        public static readonly int TriforceSpriteFrameCount = 2;
        public static readonly int TriforceSpriteStallFrameCount = defaultItemStallFrameCount;
    }
}
