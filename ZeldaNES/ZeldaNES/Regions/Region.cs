using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using ZeldaNES.Achievement;
using ZeldaNES.Cameras;
using ZeldaNES.Controllers;
using ZeldaNES.Controllers.Classes;
using ZeldaNES.Factories;
using ZeldaNES.Game_Constants;
using ZeldaNES.GameStates;
using ZeldaNES.Items;
using ZeldaNES.NPCs;
using ZeldaNES.Physics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Players.Link.Classes.States;
using ZeldaNES.RegionEditors;
using ZeldaNES.RegionFileGenerators;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Sprites.Classes.TileSprites;
using ZeldaNES.Tiles;
using ZeldaNES.Weapons;

namespace ZeldaNES.Regions
{
    public class Region: IRegion
    {
       
        public ITile BackgroundImage { get; set; }

        
        public int AreaIndex {get; set; }
        public int NextAreaIndex { get; set; }
        public GeneralConstants.CardinalDirection NextDirection { get; set; }
        public List<Area> Areas { get; set; }

        
        public List<ILink> players { get; set; }
        private WeaponFactory weaponfactory;
        private IRegionEditor regionEditor;
        public void Save() {
            this.ScaleEntitiesToWorldCoords();
            RegionFileGenerator.gen(this, "Sprint4Dungeon.yaml");
            this.ScaleEntitiesToScreenCoords();
        }
        public IRegionEditor GetRegionEditor() {
            return regionEditor;
        }


        public int ScaleToScreenCoordsX(int x) {
            x = (x  * DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale) + (DungeonTileSpriteConstants.TileSpriteSize* GeneralConstants.ImageScale)/2;
            return x;
        }
        public int ScaleToScreenCoordsY(int y)
        {
            y = y  * DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale + (DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale)/2;
            return y;
        }
        public int ScaleToWorldCoordsX(int x)
        {

            x = (x ) / (DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale);
            return x;
        }
        public int ScaleToWorldCoordsY(int y)
        {
            y = (y) / (DungeonTileSpriteConstants.TileSpriteSize * GeneralConstants.ImageScale);
            return y;
        }
        public void ScaleEntitiesToScreenCoords() {
            foreach (var area in Areas)
            {
                foreach (ITile tile in area.BoundryTiles)
                {
                    int xpos = tile.PosX;
                    int ypos = tile.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos); 
                    tile.PosX = xpos;
                    tile.PosY = ypos; 
                }
                foreach (ITile tile in area.Tiles)
                {
                    int xpos = tile.PosX;
                    int ypos = tile.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    tile.PosX = xpos;
                    tile.PosY = ypos;
                }
                foreach (INPC npc in area.Enemies)
                {
                    int xpos = npc.PosX;
                    int ypos = npc.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    npc.PosX = xpos;
                    npc.PosY = ypos;
                }
                foreach (IItem item in area.Items)
                {
                    int xpos = item.PosX;
                    int ypos = item.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    item.PosX = xpos;
                    item.PosY = ypos;
                }
            }

        }
        public void ScaleEntitiesToWorldCoords()
        {

            foreach (var area in Areas)
            {
                foreach (ITile tile in area.BoundryTiles)
                {
                    int xpos = tile.PosX;
                    int ypos = tile.PosY;
                    xpos = ScaleToWorldCoordsX(xpos);
                    ypos = ScaleToWorldCoordsY(ypos);
                    tile.PosX = xpos;
                    tile.PosY = ypos;
                }
                foreach (ITile tile in area.Tiles)
                {
                    int xpos = tile.PosX;
                    int ypos = tile.PosY;
                    xpos = ScaleToWorldCoordsX(xpos);
                    ypos = ScaleToWorldCoordsY(ypos);
                    tile.PosX = xpos;
                    tile.PosY = ypos;
                }
                foreach (INPC npc in area.Enemies)
                {
                    int xpos = npc.PosX;
                    int ypos = npc.PosY;
                    xpos = ScaleToWorldCoordsX(xpos);
                    ypos = ScaleToWorldCoordsY(ypos);
                    npc.PosX = xpos;
                    npc.PosY = ypos;
                }
                foreach (IItem item in area.Items)
                {
                    int xpos = item.PosX;
                    int ypos = item.PosY;
                    xpos = ScaleToWorldCoordsX(xpos);
                    ypos = ScaleToWorldCoordsY(ypos);
                    item.PosX = xpos;
                    item.PosY = ypos;
                }
            }

        }
        public void PopulateReference() {
            foreach (var area in Areas) {
                area.region = this;
            }
        }
        public void Initialize() {
            foreach (ILink player in players) {
                IWeaponUser weaponUser = player as IWeaponUser;
                weaponUser.SetWeaponFactory(weaponfactory);
            }
            foreach (var area in Areas)
            {
                foreach (ITile tile in area.BoundryTiles)
                {
                    int xpos = tile.PosX;
                    int ypos = tile.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    tile.PosX = xpos;
                    tile.PosY = ypos;
                }

                foreach (ITile tile in area.Tiles)
                    {
                    int xpos = tile.PosX;
                    int ypos = tile.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    tile.PosX = xpos;
                    tile.PosY = ypos;
                }
                foreach (INPC npc in area.Enemies)
                {
                    if (npc is IWeaponUser) {
                        IWeaponUser weaponUser = npc as IWeaponUser;
                        weaponUser.SetWeaponFactory(weaponfactory);
                    }
                    int xpos = npc.PosX;
                    int ypos = npc.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    npc.PosX = xpos;
                    npc.PosY = ypos;
                }
                foreach (IItem item in area.Items)
                {
                    int xpos = item.PosX;
                    int ypos = item.PosY;
                    xpos = ScaleToScreenCoordsX(xpos);
                    ypos = ScaleToScreenCoordsY(ypos);
                    item.PosX = xpos;
                    item.PosY = ypos;
                }

                area.Initialize();

            }
        }
        public void ResetQuadtree()
        {
            MainPhysicsHandler.ResetQuadtree();
        }
        public void Update()
        {
            BackgroundImage.Update();
            PlayerCamera.Instance.Update();

            if(AreaIndex != NextAreaIndex)
            {
                return;
            }

            MainPhysicsHandler.HandlePhysics(this);

            foreach (var player in players) {
                player.Update();
            }
            if (!GameState.Instance.EditorMode)
            {
                Areas[AreaIndex].Update();
            }
            if (GameState.Instance.EditorMode)
            {
                regionEditor.Update();
            }
            
            AchievementTracker.Instance.UpdateAchievementStatus();
        }
        public void Draw()
        {
            if (NextAreaIndex != AreaIndex)
            {
                DrawNext();
                TextureManager.TextureManager.Instance.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, PlayerCamera.Instance.Transform);
            }

            BackgroundImage.Draw();
            
            Areas[AreaIndex].Draw();

            if (GameState.Instance.WinMode)
            {
                if (GameState.Instance.winModeTimer > 100)
                {
                    GameState.Instance.winBackground.Draw();
                }
                else
                {
                    GameState.Instance.winModeTimer++;
                }
                
            }
            if (GameState.Instance.deathMode)
            { 
                if (GameState.Instance.winModeTimer > 100)
                {
                    GameState.Instance.winBackground.Draw();
                }
                else
                {
                    GameState.Instance.winModeTimer++;
                }
            }

            if (NextAreaIndex == AreaIndex)
            {
                foreach (var player in players)
                {
                    player.Draw();
                }
            }
            if (GameState.Instance.EditorMode) {
                regionEditor.Draw();
                MainPhysicsHandler.Draw(AreaIndex);
            }

            AchievementTracker.Instance.DisplayRecentAchievement();
            AchievementTracker.Instance.DisplayStats();
        }
        private void DrawNext()
        {
            TextureManager.TextureManager.Instance.SpriteBatch.End();
            switch (NextDirection)
            {
                case GeneralConstants.CardinalDirection.North:
                    {
                        TextureManager.TextureManager.Instance.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, PlayerCamera.Instance.UpScreen);
                        break;
                    }
                case GeneralConstants.CardinalDirection.South:
                    {
                        TextureManager.TextureManager.Instance.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, PlayerCamera.Instance.DownScreen);
                        break;
                    }
                case GeneralConstants.CardinalDirection.East:
                    {
                        TextureManager.TextureManager.Instance.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, PlayerCamera.Instance.RightScreen);
                        break;
                    }
                case GeneralConstants.CardinalDirection.West:
                    {
                        TextureManager.TextureManager.Instance.SpriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null, null, PlayerCamera.Instance.LeftScreen);
                        break;
                    }
            }
            BackgroundImage.Draw();
            Areas[NextAreaIndex].Draw();
            TextureManager.TextureManager.Instance.SpriteBatch.End();

            if(PlayerCamera.Instance.AtDestination())
            {
                AreaIndex = NextAreaIndex;
                PlayerCamera.Instance.Reset();
            }
        }
        public void Next() { 
            NextAreaIndex = (AreaIndex +1) % Areas.Count();
        }
        public void Previous()
        {
            NextAreaIndex = (AreaIndex - 1  + Areas.Count()) % Areas.Count();
        }

        private void RemoveInactiveWeapons(List<IWeapon> weapons)
        {
            List<IWeapon> weaponsToDelete = new List<IWeapon>();
            foreach (IWeapon weapon in weapons)
            {
                if (weapon.ShouldDelete)
                {
                    weaponsToDelete.Add(weapon);
                }
            }
            foreach (IWeapon weapon in weaponsToDelete)
            {
                weapons.Remove(weapon);
            }
        }
       
        public Region() {
            players = new List<ILink>();
            
            Areas = new List<Area>();
            weaponfactory = new WeaponFactory(this);
            regionEditor = new RegionEditor(this, this.weaponfactory);
        }
    }
}
