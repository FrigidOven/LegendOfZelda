using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Sprites.Classes.UISprites
{
    public static class UISpriteConstants
    {
        // dimensions
        public static readonly int PauseScreenWidth = 256;
        public static readonly int PauseScreenHeight = 223;

        // top left of pause screen
        public static readonly int PauseScreenX = 0;
        public static readonly int PauseScreenY = 0;

        // top left of start screen
        public static readonly int StartScreenX = 1;
        public static readonly int StartScreenY = 11;
        public static readonly int StartScreenWidth = 256;
        public static readonly int StartScreenHeight = 223;

        // locations of item spots to fill
        public static readonly int BButtonItemX = 64;
        public static readonly int BButtonItemY = 48;
        public static readonly int BButtonItemSize = 16;

        public static readonly int MapItemX = 50 * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item1+ UISpriteConstants.MapItemSize* GeneralConstants.ImageScale/2;
        public static readonly int MapItemY = 130 * GeneralConstants.ImageScale+ GeneralConstants.PauseMenuStartPosition.Item2 + UISpriteConstants.MapItemSize * GeneralConstants.ImageScale/2;
        public static readonly int MapItemSize = 16* GeneralConstants.ImageScale;

        public static readonly int CompassItemX = 50 *GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item1+ UISpriteConstants.CompassItemSize* GeneralConstants.ImageScale/2;
        public static readonly int CompassItemY = 170* GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2 + UISpriteConstants.CompassItemSize * GeneralConstants.ImageScale / 2; 
        public static readonly int CompassItemSize = 16*GeneralConstants.ImageScale;

        public static readonly int WorldMapX = 16;
        public static readonly int WorldMapY = 184;
        public static readonly int WorldMapWidth = 64;
        public static readonly int WorldMapHeight = 32;

        public static readonly int SpecialInventoryY = 24 * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2;
        public static readonly int SpecialInventoryItem1X = 138 * GeneralConstants.ImageScale;
        public static readonly int SpecialInventoryItem2X = 158 * GeneralConstants.ImageScale;
        public static readonly int SpecialInventoryItem3X = 170 * GeneralConstants.ImageScale;
        public static readonly int SpecialInventoryItem4X = 186 * GeneralConstants.ImageScale;
        public static readonly int SpecialInventoryItem5X = 202 * GeneralConstants.ImageScale;
        public static readonly int SpecialInventoryItem6X = 229 * GeneralConstants.ImageScale;

        public static readonly int InventoryRow1Y = 56 * GeneralConstants.ImageScale  + GeneralConstants.PauseMenuStartPosition.Item2;
        public static readonly int InventoryRow2Y = 70 * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2;
        public static readonly int InventoryItem1X = 145 * GeneralConstants.ImageScale;
        public static readonly int InventoryItem2X = 162 * GeneralConstants.ImageScale;
        public static readonly int InventoryItem3X = 186 * GeneralConstants.ImageScale;
        public static readonly int InventoryItem4X = 210 * GeneralConstants.ImageScale;

        public static readonly int DungeonMapX = 150*GeneralConstants.ImageScale;
        public static readonly int DungeonMapY = 160 * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2;
        public static readonly int DungeonMapWidth = 8;
        public static readonly int DungeonMapHeight = 8;
        public static readonly int DungeonMapTileSize = 8;

        public static readonly int CountersX = 108 * GeneralConstants.ImageScale;
        public static readonly int RupeeCounterY = 204* GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2;
        public static readonly int KeyCounterY = 220 * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2;
        public static readonly int BombCounterY = 228 * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2; 
        public static readonly int BItemX = 124;
        public static readonly int BItemY = 192;
        public static readonly int BItemSize = 16;
        public static readonly int AItemX = 148;
        public static readonly int AItemY = 192;
        public static readonly int AItemSize = 16;

        public static readonly int HealthX = 180;
        public static readonly int HealthRow1Y = 200;
        public static readonly int HealthRow2Y = 220;
        public static readonly int HealthRowSize = 8;
        public static readonly int DigitSize = (3 * UISpriteConstants.TextSpriteSize) / 4 * GeneralConstants.ImageScale;

        // sprite info for pause menu

        // there are 17 types of dungeon room sprites arranged in a row,
        // to get the one you want, take DungeonRoomSpritesX and add the 4 bit binary
        // number corresponding to the arrangement you want. The first bit represents the top
        // the second the bottom the third the left and the fourth the right.
        // for example, if you wanted a room that had an opening on the top, right, and bottom,
        // you would say x = DungeonRoomSpritesX + 0b1101 * DungeonRoomSpriteSize
        // the 17th is just a blank square the same color as the map.
        public static readonly int DungeonRoomSpritesX = 0;
        public static readonly int DungeonRoomSpritesY = 224;
        public static readonly int DungeonRoomSpriteSize = 8;

        public static readonly int HeartSpritesY = DungeonRoomSpritesY + DungeonRoomSpriteSize;
        public static readonly int HeartSpriteSize = 8;
        public static readonly int FullHeartSpriteX = 0;
        public static readonly int HalfHeartSpriteX = FullHeartSpriteX + HeartSpriteSize;
        public static readonly int EmptyHeartSpriteX = HalfHeartSpriteX + HeartSpriteSize;

        // feel free to make an array of these if you'd like
        public static readonly int TextSpriteY = HeartSpritesY + DungeonRoomSpriteSize;
        public static readonly int TextSpriteSize = 8 ;
        public static readonly int TextXSpriteX = 0;
        public static readonly int Text0SpriteX = TextXSpriteX + TextSpriteSize;
        public static readonly int Text1SpriteX = Text0SpriteX + TextSpriteSize;
        public static readonly int Text2SpriteX = Text1SpriteX + TextSpriteSize;
        public static readonly int Text3SpriteX = Text2SpriteX + TextSpriteSize;
        public static readonly int Text4SpriteX = Text3SpriteX + TextSpriteSize;
        public static readonly int Text5SpriteX = Text4SpriteX + TextSpriteSize;
        public static readonly int Text6SpriteX = Text5SpriteX + TextSpriteSize;
        public static readonly int Text7SpriteX = Text6SpriteX + TextSpriteSize;
        public static readonly int Text8SpriteX = Text7SpriteX + TextSpriteSize;
        public static readonly int Text9SpriteX = Text8SpriteX + TextSpriteSize;
        public static readonly int TextASpriteX = Text9SpriteX + TextSpriteSize;
        public static readonly int TextBSpriteX = TextASpriteX + TextSpriteSize;

    }
}
