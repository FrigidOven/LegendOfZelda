using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Doors.Classes.HiddenDoor;
using ZeldaNES.Sprites.Classes.TileSprites;

namespace ZeldaNES.Game_Constants
{
    public static class GeneralConstants

    {



        //texture constants
        public static readonly String playerTextureString = "Sprite Sheets\\Players\\Link";
        public static readonly String weaponTextureString = "Sprite Sheets\\Weapons\\Weapons";
        public static readonly String npcTextureString = "Sprite Sheets\\Enemies\\DungeonEnemies";
        public static readonly String tileTextureString = "Sprite Sheets\\Tiles\\DungeonTiles";
        public static readonly String itemTextureString = "Sprite Sheets\\Items\\Items";
        public static readonly String UIPauseMenuTextureString = "Sprite Sheets\\UI\\PauseScreen";
        public static readonly String UIStartScreenTextureString = "Sprite Sheets\\UI\\StartScreen";


        public static readonly int TotalNumberEntityTypes = 4;

        //sound constants
        public static readonly String underworldTheme = "Sound\\Songs\\UnderworldTheme";
        public static readonly String gerudoValley = "Sound\\Songs\\68 Gerudo Valley-[AudioTrimmer.com]";
        public static readonly String triforceTheme = "Sound\\Songs\\06 - Triforce";
        public static readonly String ending = "Sound\\Songs\\10 - Ending";

        public static readonly String arrowBoomerang = "Sound\\Sound Effects\\LOZ_Arrow_Boomerang";
        public static readonly String bombBlow = "Sound\\Sound Effects\\LOZ_Bomb_Blow";
        public static readonly String bombDrop = "Sound\\Sound Effects\\LOZ_Bomb_Drop";
        public static readonly String bossDamage = "Sound\\Sound Effects\\LOZ_Boss_Hit";
        public static readonly String bossScream1 = "Sound\\Sound Effects\\LOZ_Boss_Scream1";
        public static readonly String bossScream2 = "Sound\\Sound Effects\\LOZ_Boss_Scream2";
        public static readonly String bossScream3 = "Sound\\Sound Effects\\LOZ_Boss_Scream3";
        public static readonly String candle = "Sound\\Sound Effects\\LOZ_Candle";
        public static readonly String doorUnlock = "Sound\\Sound Effects\\LOZ_Door_Unlock";
        public static readonly String enemyDying = "Sound\\Sound Effects\\LOZ_Enemy_Die";
        public static readonly String enemyDamage = "Sound\\Sound Effects\\LOZ_Enemy_Hit";
        public static readonly String fanfare = "Sound\\Sound Effects\\LOZ_Fanfare";
        public static readonly String getHeart = "Sound\\Sound Effects\\LOZ_Get_Heart";
        public static readonly String getItem = "Sound\\Sound Effects\\LOZ_Get_Item";
        public static readonly String getRupee = "Sound\\Sound Effects\\LOZ_Get_Rupee";
        public static readonly String keyAppear = "Sound\\Sound Effects\\LOZ_Key_Appear";
        public static readonly String linkDying = "Sound\\Sound Effects\\LOZ_Link_Die";
        public static readonly String linkDamage = "Sound\\Sound Effects\\LOZ_Link_Hurt";
        public static readonly String lowHealth = "Sound\\Sound Effects\\LOZ_LowHealth";
        public static readonly String magicalRod = "Sound\\Sound Effects\\LOZ_MagicalRod";
        public static readonly String recorder = "Sound\\Sound Effects\\LOZ_Recorder";
        public static readonly String refillLoop = "Sound\\Sound Effects\\LOZ_Refill_Loop";
        public static readonly String secret = "Sound\\Sound Effects\\LOZ_Secret";
        public static readonly String shield = "Sound\\Sound Effects\\LOZ_Shield";
        public static readonly String shore = "Sound\\Sound Effects\\LOZ_Shore";
        public static readonly String stairs = "Sound\\Sound Effects\\LOZ_Stairs";
        public static readonly String swordCombined = "Sound\\Sound Effects\\LOZ_Sword_Combined";
        public static readonly String swordShoot = "Sound\\Sound Effects\\LOZ_Sword_Shoot";
        public static readonly String swordSlash = "Sound\\Sound Effects\\LOZ_Sword_Slash";
        public static readonly String text = "Sound\\Sound Effects\\LOZ_Text";
        public static readonly String textSlow = "Sound\\Sound Effects\\LOZ_Text_Slow";

        public enum Orientation
        {
            Up,
            UpLeft,
            UpRight,
            Down,
            DownLeft,
            DownRight,
            Left,
            Right,
        }
        public enum CardinalDirection
        { 
            North,
            South,
            East,
            West,
        }
        public enum UpgradeClasses { 
            Sword,
            Potion,
            Ring,
            Arrow,
            Candle,
            None,
        }
        public enum Entities { 
            //INPCS
            AquamentusEnemy,
            BigJellyEnemy,
            SmallJellyEnemy,
            DodongoEnemy,
            GoriyaEnemy,
            KeeseEnemy,
            OldMan,
            RopeEnemy,
            StalfoEnemy,
            Trap,
            WallMaster,
            OldManNPC,
            //ITiles
            BlackTile,
            BlockTile,
            BoundryTile,
            BlueStairTile,
            BrickTile,
            DirtTile,
            FloorTile,
            LeftFacingStatueTile,
            RightFacingStatueTile,
            WaterTile,
            WhiteStairTile,
            DummyTextTile,
            PushableBlockTile,
            //IDoors
            EastHiddenDoor,
            NorthHiddenDoor,
            SouthHiddenDoor,
            WestHiddenDoor,
            EastOpenDoor,
            NorthOpenDoor,
            SouthOpenDoor,
            WestOpenDoor,
            EastShutDoor,
            NorthShutDoor,
            SouthShutDoor,
            WestShutDoor,
            EastLockedDoor,
            NorthLockedDoor,
            SouthLockedDoor,
            WestLockedDoor,
            //IItems
            BlueCandleItem,
            BluePotionItem,
            BlueRingItem,
            BombItem,
            BookOfMagicItem,
            BowItem,
            ClockItem,
            CompassItem,
            FairyItem,
            HalfHeartItem,
            HeartContainerItem,
            HeartItem,
            KeyItem,
            LetterItem,
            MagicalKeyItem,
            MagicalRodItem,
            MagicalShieldItem,
            MagicalSwordItem,
            MapItem,
            MeatItem,
            MetalArrowItem,
            MetalBoomerangItem,
            MetalSwordItem,
            PowerBraceletItem,
            RaftItem,
            RecorderItem,
            RedCandleItem,
            RedPotionItem,
            RedRingItem,
            RupeeItem,
            StepladderItem,
            TriforceItem,
            WoodenArrowItem,
            WoodenBoomerangItem,
            WoodenSwordItem,
        }
        public enum EntitiesType
        {
            INPC,
            ITile,
            IItem,
            IDoor
        }
        public static readonly int ImageScale = 3;

        public static readonly int ScreenWidth = 256 * ImageScale;
        public static readonly int ScreenHeight = 224 * ImageScale;

        public static  float ImageScaleX = 3;
        public static float ImageScaleY = 3;
        public static readonly (int, int) PauseMenuStartPosition = (0,-47* DungeonTileSpriteConstants.TileSpriteSize/4 * ImageScale);
        public static readonly (int, int) NorthDoorPosition = (ImageScale * (DungeonTileSpriteConstants.BackgroundSpriteWidth / 2),
                                                               ImageScale * (DungeonTileSpriteConstants.DoorSpriteSize / 2));
        public static readonly (int, int) SouthDoorPosition = (ImageScale * (DungeonTileSpriteConstants.BackgroundSpriteWidth / 2),
                                                               ImageScale * (DungeonTileSpriteConstants.BackgroundSpriteHeight - DungeonTileSpriteConstants.DoorSpriteSize / 2));
        public static readonly (int, int) EastDoorPosition = (ImageScale * (DungeonTileSpriteConstants.BackgroundSpriteWidth - DungeonTileSpriteConstants.DoorSpriteSize/2),
                                                              ImageScale * (DungeonTileSpriteConstants.BackgroundSpriteHeight/2));
        public static readonly (int, int) WestDoorPosition = (ImageScale * (DungeonTileSpriteConstants.DoorSpriteSize / 2),
                                                              ImageScale * (DungeonTileSpriteConstants.BackgroundSpriteHeight / 2));

        public static readonly int UIBarHeight = DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale * 3;

    }
}
