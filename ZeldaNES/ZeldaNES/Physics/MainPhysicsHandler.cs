using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.NPCs;
using ZeldaNES.Physics.PhysicsHandlers.SubHandlers;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Tiles;
using ZeldaNES.Items;
using ZeldaNES.Weapons;
using ZeldaNES.Doors1;
using ZeldaNES.Quadtrees;
using Microsoft.Xna.Framework;
using ZeldaNES.Game_Constants;
using ZeldaNES.Screens.Classes;
using System.Runtime.CompilerServices;

namespace ZeldaNES.Physics
{
    public static class MainPhysicsHandler
    {
        private static Quadtree<IStaticObject>[] quadtrees;

        public static void HandlePhysics(IRegion region) {

            if(quadtrees == null)
            {
                quadtrees = new Quadtree<IStaticObject>[region.Areas.Count];
                for(int i = 0; i < region.Areas.Count; i++)
                { 
                    quadtrees[i] = new Quadtree<IStaticObject>(new Rectangle(0, 0, GeneralConstants.ScreenWidth, GeneralConstants.ScreenHeight));
                    foreach(var item in region.Areas[i].Items)
                    {
                        quadtrees[i].Add(item, item.Body().Hitbox.Bounds);
                    }
                    foreach(var tile in region.Areas[i].Tiles)
                    {
                        quadtrees[i].Add(tile, tile.Body().Hitbox.Bounds);
                    }
                    foreach(var tile in region.Areas[i].BoundryTiles)
                    {
                        quadtrees[i].Add(tile, tile.Body().Hitbox.Bounds);
                    }
                }
            }

            List<ITile> tiles = region.Areas[region.AreaIndex].Tiles;
            List<ITile> boundaryTiles = region.Areas[region.AreaIndex].BoundryTiles;

            List<INPC> enemies = region.Areas[region.AreaIndex].Enemies;
            List<ILink> players = region.players;
            List<IWeapon> friendlyWeapons = region.Areas[region.AreaIndex].GetFriendlyWeapons();
            List<IWeapon> hostileWeapons = region.Areas[region.AreaIndex].GetHostileWeapons();
            List<IItem> items = region.Areas[region.AreaIndex].GetItems();
            List<IDoor> doors = region.Areas[region.AreaIndex].Doors;

            EnemyStaticObjectPhysicsHandler.HandlePhysics(enemies, quadtrees[region.AreaIndex]);
            EnemyDoorPhysicsHandler.HandlePhysics(enemies, doors, region);
            PlayerEnemyPhysicsHandler.HandlePhysics(players, enemies, region);
            WeaponEnemyPhysicsHandler.HandlePhysics(friendlyWeapons, enemies);
            PlayerStaticObjectPhysicsHandler.HandlePhysics(players, quadtrees[region.AreaIndex], region, enemies);


            WeaponDoorPhysicsHandler.HandlePhysics(hostileWeapons, doors, region);
            WeaponDoorPhysicsHandler.HandlePhysics(friendlyWeapons, doors, region);
            WeaponPlayerPhysicsHandler.HandlePhysics(hostileWeapons, players);

            WeaponTilePhysicsHandler.HandlePhysics(hostileWeapons, tiles);
            WeaponTilePhysicsHandler.HandlePhysics(hostileWeapons, boundaryTiles);
            WeaponTilePhysicsHandler.HandlePhysics(friendlyWeapons, tiles);
            WeaponTilePhysicsHandler.HandlePhysics(friendlyWeapons, boundaryTiles);

            PlayerDoorPhysicsHandler.HandlePhysics(players, doors, region);
        }
        public static void ResetQuadtree()
        {
            quadtrees = null;
        }
        public static void Draw(int area)
        {
            quadtrees[area].Draw(TextureManager.TextureManager.Instance.SpriteBatch, TextureManager.TextureManager.Instance.playerTexture);
        }

        public static void AddStaticObject(IStaticObject obj, Rectangle bounds, int areaIndex)
        {
            quadtrees[areaIndex].Add(obj, bounds);
        }
    }
}
