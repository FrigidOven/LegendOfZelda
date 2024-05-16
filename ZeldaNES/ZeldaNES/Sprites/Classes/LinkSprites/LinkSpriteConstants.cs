using Microsoft.Xna.Framework;

namespace ZeldaNES.Sprites.Classes.LinkSprites
{
    public static class LinkSpriteConstants
    {
        public readonly static int SpriteSize = 48;

        public readonly static int MinimumNormalHealth = 3;
        public readonly static Color DamagedColor = Color.HotPink;

        public readonly static int UpFacingSpritesIndex = 0;
        public readonly static int DownFacingSpritesIndex = SpriteSize;
        public readonly static int LeftFacingSpritesIndex = SpriteSize * 2;
        public readonly static int RightFacingSpritesIndex = SpriteSize * 3;

        public readonly static int WalkingSpritesIndex = 0;
        public readonly static int WalkingSpritesFrameCount = 2;
        public readonly static int WalkingSpritesStallFrameCount = 10;

        public readonly static int SwingingSwordSpritesIndex = WalkingSpritesIndex + SpriteSize * WalkingSpritesFrameCount;
        public readonly static int SwingingSwordSpritesFrameCount = 4;
        public readonly static int SwingingSwordSpritesStallFrameCount = 5;

        public readonly static int UsingWeaponSpritesIndex = SwingingSwordSpritesIndex + SpriteSize * SwingingSwordSpritesFrameCount;
        public readonly static int UsingWeaponSpritesFrameCount = 1;
        public readonly static int UsingWeaponSpritesStallFrameCount = 10;

        public readonly static int PickUpSmallSpritesIndex = UsingWeaponSpritesIndex + SpriteSize * UsingWeaponSpritesFrameCount;
        public readonly static int PickUpSmallSpritesFrameCount = 1;
        public readonly static int PickUpSmallSpritesStallFrameCount = 2;

        public readonly static int PickUpLargeSpritesIndex = PickUpSmallSpritesIndex + SpriteSize * PickUpSmallSpritesFrameCount;
        public readonly static int PickUpLargeSpritesFrameCount = 1;
        public readonly static int PickUpLargeSpritesStallFrameCount = 2;
    }
}
