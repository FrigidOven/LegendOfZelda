using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.Items.Classes;
using ZeldaNES.NPCs;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Players.Link.Classes.States;
using ZeldaNES.Quadtrees;
using ZeldaNES.Regions;
using ZeldaNES.Tiles;
using ZeldaNES.Tiles.Classes;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class PlayerStaticObjectPhysicsHandler
    {
        public static void HandlePhysics(List<ILink> players, Quadtree<IStaticObject> staticObjects, IRegion region, List<INPC> enemies)
        {
            foreach(ILink player in players)
            {
                HashSet<IStaticObject> objects = staticObjects.QueryArea(player.Body().PlayerHitbox.Bounds);
                if(objects.Count > 0)
                {

                }
                foreach(IStaticObject obj in objects)
                {
                    if(obj is ITile)
                    {
                        HandleTileInteraction(player, (ITile)obj, region);
                    }
                    else
                    {
                        HandleItemInteraction(player, (IItem)obj, staticObjects, enemies);                
                    }
                }    
            }
        }
        private static void HandleItemInteraction(ILink player, IItem item, Quadtree<IStaticObject> staticObjects, List<INPC> enemies)
        {
            if (item.Body().Hitbox.IsActive)
            {
                if (item is KeyItem && enemies.Count == 0)
                {
                    player.GetInventory().AddItem(item);
                    item.SetDeletable(true);
                    staticObjects.Remove(item, item.Body().Hitbox.Bounds);
                    SoundManager.SoundManager.Instance.PlayItemPickupSound(item);
                    item.UseItem(player);
                }
                else if (item is KeyItem && enemies.Count > 0)
                {
                    //do nothing lol
                }
                else {
                    player.GetInventory().AddItem(item);
                    item.SetDeletable(true);
                    staticObjects.Remove(item, item.Body().Hitbox.Bounds);
                    SoundManager.SoundManager.Instance.PlayItemPickupSound(item);
                    item.UseItem(player);
                }
                
            }

        }
        private static void HandleTileInteraction(ILink player, ITile tile, IRegion region)
        {
            if (tile.Body().Hitbox.IsActive)
            {
                PushableBlockhandler(player, tile, player.PosX > tile.PosX);
                AdjustPlayerPosition(player.Body(), tile.Body());
                stairHandler(player, tile, region);
            }
        }
        private static void AdjustPlayerPosition(IPlayerPhysicsObject player, ITilePhysicsObject tile)
        {
            GeneralConstants.Orientation side = player.PlayerHitbox.Side(tile.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        player.PosY = tile.Hitbox.PosY - (tile.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        player.PosY = tile.Hitbox.PosY + (tile.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        player.PosX = tile.Hitbox.PosX - (tile.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        player.PosX = tile.Hitbox.PosX + (tile.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        return;
                    }
            }
        }
        private static void PushableBlockhandler(ILink player, ITile tile, bool direction)
        {
            if (tile is PushableBlockTile pushableBlock && player.GetState() is LinkWalkingDownState)
            {
                pushableBlock.pushCount++;
                if (pushableBlock.pushCount == 20 && !pushableBlock.hasTrigger)
                {
                    pushableBlock.Push();
                    pushableBlock.hasTrigger = true;
                }
            }
        }
        //hard coded stair handler, propbably need refactoring
        private static void stairHandler(ILink player, ITile tile, IRegion region)
        {
            if (tile is BlueStairTile stair)
            {
                if (region.AreaIndex == 16)
                {
                    //link new pox
                    int Nposx = 0;
                    int Nposy = 0;
                    foreach (ITile tileloop in region.Areas[17].Tiles)
                    {
                        if (tileloop is BlueStairTile)
                        {
                            Nposx = tileloop.PosX;
                            Nposy = tileloop.PosY + 16;
                        }
                    }
                    region.NextAreaIndex = 17;
                    region.players[0].Body().PosX = Nposx;
                    region.players[0].Body().PosY = Nposx;
                }
                if (region.AreaIndex == 17)
                {
                    //link new pox

                    int Nposx = 0;
                    int Nposy = 0;
                    foreach (ITile tileloop in region.Areas[16].Tiles)
                    {
                        if (tileloop is BlueStairTile)
                        {
                            Nposx = tileloop.PosX - 16 * 4;
                            Nposy = tileloop.PosY;
                        }
                    }
                    region.NextAreaIndex = 16;
                    region.players[0].Body().PosX = Nposx;
                    region.players[0].Body().PosY = Nposy;
                }
            }
        }
    }
}
