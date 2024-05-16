using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Sprites.Classes.TileSprites
{
    public static class DungeonTileSpriteConstants
    {
        // background constants
        public static readonly int BackgroundSpriteWidth = 256;
        public static readonly int BackgroundSpriteHeight = 176;

        // door constants
        public static readonly int DoorSpriteSize = 32;

        public static readonly int NorthDoorSpritesIndex = 0;
        public static readonly int SouthDoorSpritesIndex = DoorSpriteSize;
        public static readonly int WestDoorSpritesIndex = DoorSpriteSize * 2;
        public static readonly int EastDoorSpritesIndex = DoorSpriteSize * 3;


        public static readonly int OpenDoorSpritesIndex = BackgroundSpriteHeight;
        public static readonly int LockedDoorSpritesIndex = OpenDoorSpritesIndex + DoorSpriteSize;
        public static readonly int ShutDoorSpritesIndex = LockedDoorSpritesIndex + DoorSpriteSize;
        public static readonly int HiddenDoorSpritesIndex = ShutDoorSpritesIndex + DoorSpriteSize; 

        // tile constants
        public static readonly int TileSpriteSize = 16;
        public static readonly int NumberOfTiles = 10;

        public static readonly int FloorSpriteIndex = HiddenDoorSpritesIndex + DoorSpriteSize;
        public static readonly int DirtSpriteIndex = FloorSpriteIndex + TileSpriteSize;
        public static readonly int WaterSpriteIndex = DirtSpriteIndex + TileSpriteSize;
        public static readonly int BlockSpriteIndex = WaterSpriteIndex + TileSpriteSize;
        public static readonly int RightFacingStatueSpriteIndex = BlockSpriteIndex + TileSpriteSize;
        public static readonly int LeftFacingStatueSpriteIndex = RightFacingStatueSpriteIndex + TileSpriteSize;
        public static readonly int BlueStairSpriteIndex = LeftFacingStatueSpriteIndex + TileSpriteSize;
        public static readonly int WhiteStairSpriteIndex = BlueStairSpriteIndex + TileSpriteSize;
        public static readonly int BrickSpriteIndex = WhiteStairSpriteIndex + TileSpriteSize;
        public static readonly int BlackSpriteIndex = BrickSpriteIndex + TileSpriteSize;
    }
}
