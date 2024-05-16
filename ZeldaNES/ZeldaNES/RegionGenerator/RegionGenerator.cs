using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using ZeldaNES.NPCs.Classes.Keese.States;
using ZeldaNES.NPCs.Classes.Dodongo;
using ZeldaNES.NPCs.Classes.OldMan;
using ZeldaNES.NPCs.Classes.Rope;
using ZeldaNES.Items.Classes;
using ZeldaNES.Tiles.Classes;
using ZeldaNES.Regions;
using ZeldaNES.NPCs.Classes.BigJelly;
using ZeldaNES.NPCs.Classes.SmallJelly;
using ZeldaNES.NPCs.Classes.Stalfo;
using ZeldaNES.NPCs.Classes.Aquamentus;
using ZeldaNES.Players.Link.Classes;
using ZeldaNES.Doors1.HiddenDoor;
using ZeldaNES.Doors1.LockedDoor;
using ZeldaNES.Doors1.OpenDoor;
using ZeldaNES.Doors1.ShutDoor;
using ZeldaNES.NPCs.Classes.Trap;
using ZeldaNES.NPCs.Classes.WallMaster;

namespace ZeldaNES
{
    public static class RegionGenerator
    {
         public static Region gen(string filename)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new PascalCaseNamingConvention())
                .WithTagMapping("!LinkPlayer", typeof(Link))//player
                .WithTagMapping("!KeeseEnemy", typeof(KeeseEnemy))//enemy
                .WithTagMapping("!DodongoEnemy", typeof(DodongoEnemy))
                .WithTagMapping("!OldMan", typeof(OldManNPC))
                .WithTagMapping("!RopeEnemy", typeof(RopeEnemy))
                .WithTagMapping("!AquamentusEnemy", typeof(AquamentusEnemy))
                .WithTagMapping("!BigJellyEnemy", typeof(BigJellyEnemy))
                .WithTagMapping("!GoriyaEnemy", typeof(GoriyaEnemy))
                .WithTagMapping("!SmallJellyEnemy", typeof(SmallJellyEnemy))
                .WithTagMapping("!StalfoEnemy", typeof(StalfoEnemy))
                .WithTagMapping("!TrapEnemy", typeof(TrapEnemy))
                .WithTagMapping("!WallMasterEnemy", typeof(WallMasterEnemy))
                .WithTagMapping("!BlueCandleItem", typeof(BlueCandleItem))//item
                .WithTagMapping("!BluePotionItem", typeof(BluePotionItem))
                .WithTagMapping("!BlueRingItem", typeof(BlueRingItem))
                .WithTagMapping("!BombItem", typeof(BombItem))
                .WithTagMapping("!BookOfMagicItem", typeof(BookOfMagicItem))
                .WithTagMapping("!BowItem", typeof(BowItem))
                .WithTagMapping("!ClockItem", typeof(ClockItem))
                .WithTagMapping("!CompassItem", typeof(CompassItem))
                .WithTagMapping("!FairyItem", typeof(FairyItem))
                .WithTagMapping("!HalfHeartItem", typeof(HalfHeartItem))
                .WithTagMapping("!HeartContainerItem", typeof(HeartContainerItem))
                .WithTagMapping("!HeartItem", typeof(HeartItem))
                .WithTagMapping("!KeyItem", typeof(KeyItem))
                .WithTagMapping("!LtterItem", typeof(LetterItem))
                .WithTagMapping("!MagicalKeyItem", typeof(MagicalKeyItem))
                .WithTagMapping("!MagicalRodItem", typeof(MagicalRodItem))
                .WithTagMapping("!MagicalShieldItem", typeof(MagicalShieldItem))
                .WithTagMapping("!MagicalSwordItem", typeof(MagicalSwordItem))
                .WithTagMapping("!MapItem", typeof(MapItem))
                .WithTagMapping("!MeatItem", typeof(MeatItem))
                .WithTagMapping("!MetalArrowItems", typeof(MetalArrowItem))
                .WithTagMapping("!MetalBoomerangItem", typeof(MetalBoomerangItem))
                .WithTagMapping("!MetalSwordItem", typeof(MetalSwordItem))
                .WithTagMapping("!PowerBraceletItem", typeof(PowerBraceletItem))
                .WithTagMapping("!RaftItem", typeof(RaftItem))
                .WithTagMapping("!RecorderItem", typeof(RecorderItem))
                .WithTagMapping("!RedCandleItem", typeof(RedCandleItem))
                .WithTagMapping("!RedPotionItem", typeof(RedPotionItem))
                .WithTagMapping("!RedRingItem", typeof(RedRingItem))
                .WithTagMapping("!RupeeItem", typeof(RupeeItem))
                .WithTagMapping("!StepladderItem", typeof(StepladderItem))
                .WithTagMapping("!TriforceItem", typeof(TriforceItem))
                .WithTagMapping("!WoodenArrowItem", typeof(WoodenArrowItem))
                .WithTagMapping("!WoodenBoomerangItem", typeof(WoodenBoomerangItem))
                .WithTagMapping("!WoodenSwordItem", typeof(WoodenSwordItem))
                .WithTagMapping("!BlockTile", typeof(BlockTile))//tiles
                .WithTagMapping("!BoundryTile", typeof(BoundryTile))
                .WithTagMapping("!BlackTile", typeof(BlackTile))
                .WithTagMapping("!BlueStairTile", typeof(BlueStairTile))
                .WithTagMapping("!BrickTile", typeof(BrickTile))
                .WithTagMapping("!DirtTile", typeof(DirtTile))
                .WithTagMapping("!FloorTile", typeof(FloorTile))
                .WithTagMapping("!LeftFacingStatueTile", typeof(LeftFacingStatueTile))
                .WithTagMapping("!RightFacingStatueTile", typeof(RightFacingStatueTile))
                .WithTagMapping("!WaterTile", typeof(WaterTile))
                .WithTagMapping("!WhiteStairTile", typeof(WhiteStairTile))
                .WithTagMapping("!FirstDungeonBackgroundTile", typeof(FirstDungeonBackgroundTile))
                .WithTagMapping("!DummyTextTile", typeof(DummyTextTile))
                .WithTagMapping("!PushableBlockTile", typeof(PushableBlockTile))
                /*
                .WithTagMapping("!NorthOpenDoor", typeof(NorthOpenDoor))//door
                .WithTagMapping("!SouthOpenDoor", typeof(SouthOpenDoor))
                .WithTagMapping("!EastOpenDoor", typeof(EastOpenDoor))
                .WithTagMapping("!WestOpenDoor", typeof(WestOpenDoor))
                .WithTagMapping("!NorthLockedDoor", typeof(NorthLockedDoor))
                .WithTagMapping("!SouthLockedDoor", typeof(SouthLockedDoor))
                .WithTagMapping("!EastLockedDoor", typeof(EastLockedDoor))
                .WithTagMapping("!WestLockedDoor", typeof(WestLockedDoor))
                .WithTagMapping("!NorthHiddenDoor", typeof(NorthHiddenDoor))
                .WithTagMapping("!SouthHiddenDoor", typeof(SouthHiddenDoor))
                .WithTagMapping("!EastHiddenDoor", typeof(EastHiddenDoor))
                .WithTagMapping("!WestHiddenDoor", typeof(WestHiddenDoor))
                .WithTagMapping("!NorthShutDoor", typeof(NorthShutDoor))
                .WithTagMapping("!SouthShutDoor", typeof(SouthShutDoor))
                .WithTagMapping("!EastShutDoor", typeof(EastShutDoor))
                .WithTagMapping("!WestShutDoor", typeof(WestShutDoor))
                */
                .WithTagMapping("!NorthOpenDoor", typeof(OpenDoor))//door
                .WithTagMapping("!SouthOpenDoor", typeof(OpenDoor))
                .WithTagMapping("!EastOpenDoor", typeof(OpenDoor))
                .WithTagMapping("!WestOpenDoor", typeof(OpenDoor))
                .WithTagMapping("!NorthLockedDoor", typeof(LockedDoor))
                .WithTagMapping("!SouthLockedDoor", typeof(LockedDoor))
                .WithTagMapping("!EastLockedDoor", typeof(LockedDoor))
                .WithTagMapping("!WestLockedDoor", typeof(LockedDoor))
                .WithTagMapping("!NorthHiddenDoor", typeof(HiddenDoor))
                .WithTagMapping("!SouthHiddenDoor", typeof(HiddenDoor))
                .WithTagMapping("!EastHiddenDoor", typeof(HiddenDoor))
                .WithTagMapping("!WestHiddenDoor", typeof(HiddenDoor))
                .WithTagMapping("!NorthShutDoor", typeof(ShutDoor))
                .WithTagMapping("!SouthShutDoor", typeof(ShutDoor))
                .WithTagMapping("!EastShutDoor", typeof(ShutDoor))
                .WithTagMapping("!WestShutDoor", typeof(ShutDoor))
                .WithTagMapping("!HiddenDoor", typeof(HiddenDoor))
                .WithTagMapping("!ShutDoor", typeof(ShutDoor))
                .WithTagMapping("!LockedDoor", typeof(LockedDoor))
                .WithTagMapping("!OpenDoor", typeof(OpenDoor))
                .Build();

            var result = deserializer.Deserialize<Region>(File.OpenText(filename));
            return result;
        }
    }
}
