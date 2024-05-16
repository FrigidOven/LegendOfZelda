using System;
using System.Collections.Generic;
using ZeldaNES.Doors1;
using System.Reflection;
using ZeldaNES.Game_Constants;
using ZeldaNES.GameStates;
using ZeldaNES.Items;
using ZeldaNES.Items.Classes;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Sprites.Classes.UISprites;
using ZeldaNES.Tiles.Classes;
using System.Diagnostics;
using YamlDotNet.Serialization;


namespace ZeldaNES.UI.PauseMenus
{
    public class PauseMenu
    {
        bool hasMap = true;
        private ISprite sprite;
        ItemSet itemSet = new ItemSet();
        int EquipSlots = 0;
        int PassiveSlots = 0;
        IItem removal = null;
        IItem mapPosition;
        DungeonMapTile DungeonMap = new DungeonMapTile(200, 200);
        List<ThreeDigitTile> Counters = new List<ThreeDigitTile>();
        HealthBarTile HealthBar = new HealthBarTile(
            UISpriteConstants.HealthX * GeneralConstants.ImageScale,
            UISpriteConstants.HealthRow2Y * GeneralConstants.ImageScale + GeneralConstants.PauseMenuStartPosition.Item2);
        int counter = 0;
        public int PosX
        {
            get; set;
        }
        public int PosY
        {
            get; set;
        }
        public PauseMenu()
        {
            PosX = GeneralConstants.PauseMenuStartPosition.Item1;
            PosY = GeneralConstants.PauseMenuStartPosition.Item2;
            Counters.Add(new ThreeDigitTile(UISpriteConstants.CountersX, UISpriteConstants.RupeeCounterY));
            Counters.Add(new ThreeDigitTile(UISpriteConstants.CountersX, UISpriteConstants.KeyCounterY));
            Counters.Add(new ThreeDigitTile(UISpriteConstants.CountersX, UISpriteConstants.BombCounterY));


            sprite = new PauseMenuBackgroundSprite(this);
        }
        public void GenerateMapFromRegion(IRegion region)
        {
            // area, direction relative to last room, position to draw at
            Stack<(Area, GeneralConstants.CardinalDirection, (int, int))> toProcess = new();
            HashSet<int> visited = new();

            // sprite size
            int offset =  UISpriteConstants.DungeonMapTileSize * GeneralConstants.ImageScale;

            // push first room and mark it as visited
            toProcess.Push((region.Areas[region.AreaIndex], GeneralConstants.CardinalDirection.North, (UISpriteConstants.DungeonMapX, UISpriteConstants.DungeonMapY)));
            visited.Add(region.AreaIndex);

            while (toProcess.Count > 0)
            {
                (Area, GeneralConstants.CardinalDirection, (int, int)) area = toProcess.Pop();
                DungeonMap.rooms.Add(new DungeonRoomMapTile(area.Item3.Item1, area.Item3.Item2));

                foreach (var door in area.Item1.Doors)
                {
                    (int, int) coords = (door.GetCardinalPosition()) switch
                    {
                        GeneralConstants.CardinalDirection.North => (area.Item3.Item1, area.Item3.Item2 - offset),
                        GeneralConstants.CardinalDirection.South => (area.Item3.Item1, area.Item3.Item2 + offset),
                        GeneralConstants.CardinalDirection.West => (area.Item3.Item1 - offset, area.Item3.Item2),
                        _ => (area.Item3.Item1 + offset, area.Item3.Item2)
                    };

                    if (!visited.Contains(door.Index))
                    {
                        toProcess.Push((region.Areas[door.Index], door.GetCardinalPosition(), (coords.Item1, coords.Item2)));
                        visited.Add(door.Index);
                    }
                }
            }
        }
        public void GenerateMapFromRegionOld(IRegion region) {

            (int, int) north = (0, -UISpriteConstants.DungeonMapTileSize * GeneralConstants.ImageScale);
            (int, int) south = (0, UISpriteConstants.DungeonMapTileSize * GeneralConstants.ImageScale);
            (int, int) east = (UISpriteConstants.DungeonMapTileSize * GeneralConstants.ImageScale, 0);
            (int, int) west = (-UISpriteConstants.DungeonMapTileSize * GeneralConstants.ImageScale, 0);
            DungeonRoomMapTile roomRef = new DungeonRoomMapTile(UISpriteConstants.DungeonMapX, UISpriteConstants.DungeonMapY);
            List<KeyValuePair<Area, (DungeonRoomMapTile, bool)>> memoryBuffer = new List<KeyValuePair<Area, (DungeonRoomMapTile, bool)>>();
            //we add the first room and set that the boolean indicating the doors have not been explored
            DungeonMap.memory.Add(
                    region.Areas[0],//Key
                    (roomRef, false));//value
            DungeonMap.rooms.Add(roomRef);
            while (DungeonMap.memory.Count<region.Areas.Count) {
                if(DungeonMap.memory.Count == 17)
                {
                    break;
                }    
                foreach (KeyValuePair<Area, (DungeonRoomMapTile, bool)> entry in DungeonMap.memory)
                {
                    if (!entry.Value.Item2)
                    {
                        int origX = entry.Value.Item1.PosX;
                        int origY = entry.Value.Item1.PosY;
                        foreach (IDoor door in entry.Key.Doors)
                        {
                            Area possibleArea = region.Areas[door.Index];
                            if (!DungeonMap.memory.ContainsKey(possibleArea))
                            {
                                switch (door.GetCardinalPosition())
                                {
                                    case GeneralConstants.CardinalDirection.North:
                                        DungeonRoomMapTile newRoomRef = new DungeonRoomMapTile(origX + north.Item1, origY + north.Item2);
                                        DungeonMap.rooms.Add(newRoomRef);
                                        memoryBuffer.Add(new KeyValuePair<Area, (DungeonRoomMapTile, bool)>(possibleArea,//Key
                                         (newRoomRef, false)));//value

                                        break;
                                    case GeneralConstants.CardinalDirection.South:
                                        newRoomRef = new DungeonRoomMapTile(origX + south.Item1, origY + south.Item2);
                                        DungeonMap.rooms.Add(newRoomRef);
                                        memoryBuffer.Add(new KeyValuePair<Area, (DungeonRoomMapTile, bool)>(possibleArea,//Key
                                        (newRoomRef, false)));//value


                                        break;
                                    case GeneralConstants.CardinalDirection.East:
                                        newRoomRef = new DungeonRoomMapTile(origX + east.Item1, origY + east.Item2);
                                        DungeonMap.rooms.Add(newRoomRef);
                                        memoryBuffer.Add(new KeyValuePair<Area, (DungeonRoomMapTile, bool)>(possibleArea,//Key
                                        (newRoomRef, false)));//value

                                        break;
                                    case GeneralConstants.CardinalDirection.West:
                                        newRoomRef = new DungeonRoomMapTile(origX + west.Item1, origY + west.Item2);
                                        DungeonMap.rooms.Add(newRoomRef);
                                        memoryBuffer.Add(new KeyValuePair<Area, (DungeonRoomMapTile, bool)>(possibleArea,//Key
                                        (newRoomRef, false)));//value

                                        break;
                                }
                            }

                        }
                    }
                    DungeonMap.memory[entry.Key] = (entry.Value.Item1, true);
                }
                foreach (var entry in memoryBuffer)
                {
                    if (!DungeonMap.memory.ContainsKey(entry.Key))
                    {
                        DungeonMap.memory.Add(entry.Key, entry.Value);
                    }
                }
            }

        }
        private void AddItemPassive(IItem item, ILink link) 
        {
            switch (PassiveSlots)
            {
                case 0:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem1X, UISpriteConstants.SpecialInventoryY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem1X, UISpriteConstants.SpecialInventoryY });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        PassiveSlots++;
                        break;
                    }
                case 1:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem2X, UISpriteConstants.SpecialInventoryY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem2X, UISpriteConstants.SpecialInventoryY });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        PassiveSlots++;
                        break;
                    }
                case 2:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem3X, UISpriteConstants.SpecialInventoryY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem3X, UISpriteConstants.SpecialInventoryY });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        PassiveSlots++;
                        break;
                    }
                case 3:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem4X, UISpriteConstants.SpecialInventoryY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem4X, UISpriteConstants.SpecialInventoryY });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        PassiveSlots++;
                        break;
                    }
                case 4:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem5X, UISpriteConstants.SpecialInventoryY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem5X, UISpriteConstants.SpecialInventoryY });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        PassiveSlots++;
                        break;
                    }
                case 5:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem6X, UISpriteConstants.SpecialInventoryY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.SpecialInventoryItem6X, UISpriteConstants.SpecialInventoryY });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        PassiveSlots++;
                        break;
                    }
            }
        }
        private void AddItemEquip(IItem item, ILink link)
        {
            switch (EquipSlots)
            {
                case 0:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem1X, UISpriteConstants.InventoryRow1Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem1X, UISpriteConstants.InventoryRow1Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 1:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem2X, UISpriteConstants.InventoryRow1Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem2X, UISpriteConstants.InventoryRow1Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 2:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem3X, UISpriteConstants.InventoryRow1Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem3X, UISpriteConstants.InventoryRow1Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 3:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem4X, UISpriteConstants.InventoryRow1Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem4X, UISpriteConstants.InventoryRow1Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 4:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem1X, UISpriteConstants.InventoryRow2Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem1X, UISpriteConstants.InventoryRow2Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 5:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem2X, UISpriteConstants.InventoryRow2Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem2X, UISpriteConstants.InventoryRow2Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 6:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem3X, UISpriteConstants.InventoryRow2Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem3X, UISpriteConstants.InventoryRow2Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
                case 7:
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem4X, UISpriteConstants.InventoryRow2Y });
                        object itemInstance2 = itemCtor.Invoke(new object[] { UISpriteConstants.InventoryItem4X, UISpriteConstants.InventoryRow2Y });

                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        EquipSlots++;
                        break;
                    }
            }
        
    }
        public void ReadInventory(ILink link)
        {
            foreach (IItem item in link.GetInventory().ItemsBuffer)
            {
                if (item is IMap)
                {

                    itemSet.Add(new MapItem(UISpriteConstants.MapItemX, UISpriteConstants.MapItemY));
                    link.GetInventory().Items.Add(new MapItem(UISpriteConstants.MapItemX, UISpriteConstants.MapItemY));
                    DungeonMap.setVisible(true);

                }
                if (item is ICompass)
                {
                    itemSet.Add(new CompassItem(UISpriteConstants.CompassItemX, UISpriteConstants.CompassItemY));
                    link.GetInventory().Items.Add(new CompassItem(UISpriteConstants.CompassItemX, UISpriteConstants.CompassItemY));
                }
                if (item is IUpgradeItem) {
                    removal = null;
                    foreach (IItem upperItem in itemSet.getList()) 
                    {
                        if (upperItem is IUpgradeItem) {
                            if (((IUpgradeItem)item).GetUpgradeClass() == ((IUpgradeItem)upperItem).GetUpgradeClass()
                                && ((IUpgradeItem)item).GetLevel() > ((IUpgradeItem)upperItem).GetLevel()) 
                            { //replace existing item with upgrade

                                removal = upperItem;
                            }
                        }
                    }
                    if (removal != null)
                    {
                        Type ourItemsType = item.GetType();
                        ConstructorInfo itemCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                        object itemInstance1 = itemCtor.Invoke(new object[] { removal.PosX, removal.PosY });
                        object itemInstance2 = itemCtor.Invoke(new object[] { removal.PosX, removal.PosY });
                        itemSet.getList().Remove(removal);
                        itemSet.Add((IItem)itemInstance1);
                        link.GetInventory().Items.Add((IItem)itemInstance2);
                        link.GetInventory().Items.Remove(removal);
                        
                    }
                    

                }



                if (item is IPassiveItem && removal == null)
                {
                    AddItemPassive(item, link);
                }
                if (item is IEquippableItem && removal == null)
                {
                    AddItemEquip(item, link);
                }
                removal = null;
            }
            link.GetInventory().ItemsBuffer.Clear();


            HealthBar.SetValue(link.Health, link.HealthCapacity);

            //do rupee digits
            Counters[0].SetValue(link.GetInventory().Rupees);///rupees
            Counters[1].SetValue(link.GetInventory().Keys);//keys
            Counters[2].SetValue(link.GetInventory().Bombs);//bombs
           
        }

        public void Update()
        {
            HealthBar.Update();
            DungeonMap.Update();
            itemSet.Update();
            foreach (ThreeDigitTile counter in Counters)
            {
                counter.Update();
            }
            if (GameState.Instance.PauseScreenMode && PosY + 16 * 13 * GeneralConstants.ImageScale < -1 * GeneralConstants.PauseMenuStartPosition.Item2)
            {
                HealthBar.PosY += GeneralConstants.ImageScale * 2;
                DungeonMap.PosY += GeneralConstants.ImageScale * 2;
                itemSet.IncrementPosY( GeneralConstants.ImageScale * 2);


                foreach (ThreeDigitTile counter in Counters)
                {

                    counter.PosY += GeneralConstants.ImageScale * 2;
                }
                PosY += GeneralConstants.ImageScale * 2;

            }
            else if (!GameState.Instance.PauseScreenMode && PosY > GeneralConstants.PauseMenuStartPosition.Item2)
            {
                HealthBar.PosY -= GeneralConstants.ImageScale * 2;
                DungeonMap.PosY -= GeneralConstants.ImageScale * 2;
                itemSet.IncrementPosY(-GeneralConstants.ImageScale * 2);

                foreach (ThreeDigitTile counter in Counters)
                {
                    counter.PosY -= GeneralConstants.ImageScale * 2;
                }
                PosY -= GeneralConstants.ImageScale * 2;

            }
            sprite.Update();
        }

        public void Draw()
        {
            sprite.Draw();
            HealthBar.Draw();

            DungeonMap.Draw();
            
            foreach (ThreeDigitTile counter in Counters)
            {
                counter.Draw();
            }
            itemSet.Draw();


        }
    }
}
