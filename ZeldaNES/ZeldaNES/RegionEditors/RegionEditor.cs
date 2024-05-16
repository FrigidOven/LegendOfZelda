using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using ZeldaNES.Doors1;
using ZeldaNES.Doors.Classes;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.Items.Classes;
using ZeldaNES.NPCs;
using ZeldaNES.NPCs.Classes;
using ZeldaNES.Regions;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Sprint2;
using ZeldaNES.Sprites;
using ZeldaNES.Tiles;
using ZeldaNES.Tiles.Classes;
using ZeldaNES.Weapons;


namespace ZeldaNES.RegionEditors
{
    public class RegionEditor: IRegionEditor

    {
        private bool regionEditMode = false;
        private List<ISprint2> editorElementMultiplexor;
        private IRegion regionRef;
        private int CurrentEntityTypeIndex = 0;
        private List<GeneralConstants.EntitiesType> types;
        private WeaponFactory weaponFactory;
        public int DoorDrawLinkingIndex { get; set; }
        public DebugTextSprite debug;
        public List<DebugTextSprite> doorDebug;
        public string debugMessage = "";
        

        public RegionEditor(IRegion region, WeaponFactory weaponFactory)
        {
            debug = new DebugTextSprite(0, 0);
            doorDebug = new List<DebugTextSprite>();
            types = new List<GeneralConstants.EntitiesType>();
            regionRef = region;
            this.weaponFactory = weaponFactory;
            editorElementMultiplexor = new List<ISprint2>();
            editorElementMultiplexor.Add(new Sprint2Door(0, 0));
            types.Add(GeneralConstants.EntitiesType.IDoor);

            editorElementMultiplexor.Add(new Sprint2NPC(0, 0));
            types.Add(GeneralConstants.EntitiesType.INPC);

            editorElementMultiplexor.Add(new Sprint2Tile(0, 0));
            types.Add(GeneralConstants.EntitiesType.ITile);

            editorElementMultiplexor.Add(new Sprint2Item(0, 0));
            types.Add(GeneralConstants.EntitiesType.IItem);


        }
        public void Initialize() {
        }
  
        public void AddRegionElementMultiplexor()
        {
            
            GeneralConstants.Entities type = editorElementMultiplexor[CurrentEntityTypeIndex].GetEntity();
            GeneralConstants.EntitiesType family = editorElementMultiplexor[CurrentEntityTypeIndex].GetEntityType();
            int mousex = editorElementMultiplexor[CurrentEntityTypeIndex].GetPosX();
            // fixes the wrong placement due to UI shift
            int mousey = editorElementMultiplexor[CurrentEntityTypeIndex].GetPosY() - GeneralConstants.UIBarHeight;


            int worldx = regionRef.ScaleToWorldCoordsX(mousex);
            int worldy = regionRef.ScaleToWorldCoordsY(mousey);

            int screenx = regionRef.ScaleToScreenCoordsX(worldx);
            int screeny = regionRef.ScaleToScreenCoordsY(worldy);

            editorElementMultiplexor[CurrentEntityTypeIndex].SetPosX(screenx);
            editorElementMultiplexor[CurrentEntityTypeIndex].SetPosY(screeny + GeneralConstants.UIBarHeight);

            switch (family)
            {
                case GeneralConstants.EntitiesType.INPC:
                    Sprint2NPC ourISprintNPC = editorElementMultiplexor[CurrentEntityTypeIndex] as Sprint2NPC;
                    Type ourNPCsType = ourISprintNPC.npcRef[ourISprintNPC.currentIndex].GetType();
                    ConstructorInfo ctor = ourNPCsType.GetConstructor(new[] { typeof(int), typeof(int) });
                    object npcInstance = ctor.Invoke(new object[] { editorElementMultiplexor[CurrentEntityTypeIndex].GetPosX(), editorElementMultiplexor[CurrentEntityTypeIndex].GetPosY() });
                    if (typeof(IWeaponUser).IsAssignableFrom(ourNPCsType)) {
                        IWeaponUser weaponUser = npcInstance as IWeaponUser;
                        weaponUser.SetWeaponFactory(weaponFactory);
                    }
                    regionRef.Areas[regionRef.AreaIndex].Enemies.Add((INPC)npcInstance);
                    break;
                case GeneralConstants.EntitiesType.IItem:
                    Sprint2Item ourISprintItem = editorElementMultiplexor[CurrentEntityTypeIndex] as Sprint2Item;
                    Type ourItemsType = ourISprintItem.itemRef[ourISprintItem.currentIndex].GetType();
                    ConstructorInfo npcCtor = ourItemsType.GetConstructor(new[] { typeof(int), typeof(int) });
                    object itemInstance = npcCtor.Invoke(new object[] { editorElementMultiplexor[CurrentEntityTypeIndex].GetPosX(), editorElementMultiplexor[CurrentEntityTypeIndex].GetPosY() });
                    regionRef.Areas[regionRef.AreaIndex].Items.Add((IItem)itemInstance);
                    break;
                case GeneralConstants.EntitiesType.ITile:
                    Sprint2Tile ourISprintTile = editorElementMultiplexor[CurrentEntityTypeIndex] as Sprint2Tile;
                    Type ourTilesType = ourISprintTile.tileRef[ourISprintTile.currentIndex].GetType();
                    
                    ConstructorInfo tileCtor = ourTilesType.GetConstructor(new[] { typeof(int), typeof(int) });
                    object tileInstance = tileCtor.Invoke(new object[] { editorElementMultiplexor[CurrentEntityTypeIndex].GetPosX(), editorElementMultiplexor[CurrentEntityTypeIndex].GetPosY() });
                    if (ourTilesType == typeof(BoundryTile))
                    {
                        regionRef.Areas[regionRef.AreaIndex].BoundryTiles.Add((ITile)tileInstance);
                    }
                    else
                    {
                        regionRef.Areas[regionRef.AreaIndex].Tiles.Add((ITile)tileInstance);
                    }
                    break;
                case GeneralConstants.EntitiesType.IDoor:
                    Sprint2Door ourISprintDoor = editorElementMultiplexor[CurrentEntityTypeIndex] as Sprint2Door;
                    IDoor ourIDoor = ourISprintDoor.doorRef[ourISprintDoor.currentIndex] as IDoor;
                    
                    Type ourDoorsType = ourISprintDoor.doorRef[ourISprintDoor.currentIndex].GetType();
                    Type  ourLinkedDoorsType = ourIDoor.GetLinkingType();
                    
                    ConstructorInfo doorCtor = ourDoorsType.GetConstructor(new Type[0]);
                    ConstructorInfo linkingDoorCtor = ourLinkedDoorsType.GetConstructor(new Type[0]);

                    object doorInstance = doorCtor.Invoke(new object[0]);

                    IDoor castedInstance = (IDoor)doorInstance;
                    castedInstance.Index = DoorDrawLinkingIndex;

                    if (regionRef.Areas.Count() - 1 < DoorDrawLinkingIndex)
                    { //we need to create the requisite area

                        Area newArea = new Area(regionRef);
                        object linkedDoorInstance = linkingDoorCtor.Invoke(new object[0]);//so we must need to create the door
                        IDoor castedLinkedDoorInstance = (IDoor)linkedDoorInstance;
                        castedLinkedDoorInstance.Index = regionRef.AreaIndex;
                        newArea.Doors.Add(castedLinkedDoorInstance);
                        regionRef.Areas.Add(newArea);
                    }
                    else {
                        Area linkedArea = regionRef.Areas[DoorDrawLinkingIndex];
                        object linkedDoorInstance = linkingDoorCtor.Invoke(new object[0]);//so we must need to create the door
                        IDoor castedLinkedDoorInstance = (IDoor)linkedDoorInstance;
                        castedLinkedDoorInstance.Index = regionRef.AreaIndex;
                        linkedArea.Doors.Add(castedLinkedDoorInstance);
                    }
                    regionRef.Areas[regionRef.AreaIndex].Doors.Add((IDoor)doorInstance);
                    break;
            }
        }
        public void Draw()
        {

            GeneralConstants.EntitiesType type = editorElementMultiplexor[CurrentEntityTypeIndex].GetEntityType();
            switch (type)
            {
                case GeneralConstants.EntitiesType.INPC:
                    editorElementMultiplexor[CurrentEntityTypeIndex].Draw();
                    break;
                case GeneralConstants.EntitiesType.IItem:
                    editorElementMultiplexor[CurrentEntityTypeIndex].Draw();
                    break;
                case GeneralConstants.EntitiesType.ITile:
                    editorElementMultiplexor[CurrentEntityTypeIndex].Draw();
                    break;
                case GeneralConstants.EntitiesType.IDoor:
                    editorElementMultiplexor[CurrentEntityTypeIndex].Draw();
                     break;
            }
            foreach (IDoor door in regionRef.Areas[regionRef.AreaIndex].Doors) {
                door.DrawDebug();
            }
            foreach (ITile tile in regionRef.Areas[regionRef.AreaIndex].BoundryTiles)
            {
                BoundryTile ourTile = tile as BoundryTile;
                ourTile.Draw();
            }
            debug.Draw(debugMessage);
        }
        public void Undo() {
            Sprint2Tile sprint2Tile = editorElementMultiplexor[CurrentEntityTypeIndex] as Sprint2Tile;//undoing boundrytiles since they are in a different list
            if (sprint2Tile != null) {
                Type theType = sprint2Tile.tileRef[sprint2Tile.currentIndex].GetType();
                Debug.WriteLine(theType);
                if (theType == typeof(BoundryTile))
                {
                    int len = regionRef.Areas[regionRef.AreaIndex].BoundryTiles.Count() - 1;
                    if (len >= 0)
                    {
                        regionRef.Areas[regionRef.AreaIndex].BoundryTiles.RemoveAt(len);
                    }
                    return;

                }
            }
           
            
            switch (types[CurrentEntityTypeIndex])
            {

                case GeneralConstants.EntitiesType.INPC:
                    int len = regionRef.Areas[regionRef.AreaIndex].Enemies.Count() - 1;
                    if (len >= 0)
                    {
                        regionRef.Areas[regionRef.AreaIndex].Enemies.RemoveAt(len);
                    }
                    break;
                case GeneralConstants.EntitiesType.IItem:
                    
                    len = regionRef.Areas[regionRef.AreaIndex].Items.Count() - 1;


                    if (len >= 0)
                    {

                        regionRef.Areas[regionRef.AreaIndex].Items.RemoveAt(len);
                    }
                    break;
                case GeneralConstants.EntitiesType.ITile:

                    len = regionRef.Areas[regionRef.AreaIndex].Tiles.Count() - 1;
                    if (len >= 0)
                    {

                        regionRef.Areas[regionRef.AreaIndex].Tiles.RemoveAt(len);
                    }
                    break;
                case GeneralConstants.EntitiesType.IDoor:
                    len = regionRef.Areas[regionRef.AreaIndex].Doors.Count() - 1;
                    if (len >= 0) { 

                        regionRef.Areas[regionRef.AreaIndex].Doors.RemoveAt(len);
                     }
                    break;
            }
        }
        public void Update() {
            debugMessage = "#Areas "+ regionRef.Areas.Count()+"\nAreaIndex "+regionRef.AreaIndex + "\nDoorLinkingIndex "+DoorDrawLinkingIndex+"\nRemoving "+types[CurrentEntityTypeIndex];
            foreach (DebugTextSprite debug in doorDebug) {
                doorDebug.Remove(debug);
            }
           
        }
        public ISprint2 GetRegionElementMultiplexor()
        {
            return editorElementMultiplexor[CurrentEntityTypeIndex];
        }
      
        public void AddArea() {
            Area area = new Area(regionRef);
            area.Initialize();
            regionRef.Areas.Add(area);
        }
        public void RemoveArea()
        {
            int removalIdx = regionRef.Areas.Count()-1;
            if (regionRef.AreaIndex != removalIdx) {
                regionRef.Areas.RemoveAt(removalIdx);
            }
          
        }

        public void Next() {
            CurrentEntityTypeIndex = (CurrentEntityTypeIndex + 1) % GeneralConstants.TotalNumberEntityTypes;
        }
        public void Previous()
        {
            CurrentEntityTypeIndex = (CurrentEntityTypeIndex - 1 + GeneralConstants.TotalNumberEntityTypes)  % GeneralConstants.TotalNumberEntityTypes;
        }
    }
}
