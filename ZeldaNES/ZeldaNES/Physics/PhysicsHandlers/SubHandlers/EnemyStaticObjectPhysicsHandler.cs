using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Items;
using ZeldaNES.NPCs;
using ZeldaNES.NPCs.Classes.Rope;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Quadtrees;
using ZeldaNES.Regions;
using ZeldaNES.Tiles;
using ZeldaNES.NPCs.Classes.Trap;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class EnemyStaticObjectPhysicsHandler
    {
        public static void HandlePhysics(List<INPC> enemies, Quadtree<IStaticObject> staticObjects)
        {
            foreach (INPC enemy in enemies)
            {
                HashSet<IStaticObject> objects = staticObjects.QueryArea(enemy.Body().Hitbox.Bounds);
                foreach (IStaticObject obj in objects)
                {
                    if (obj is ITile)
                    {
                        HandleTileInteraction(enemy, (ITile)obj);
                    }
                }
            }
        }
        private static void HandleTileInteraction(INPC enemy, ITile tile)
        {
            if (tile.Body().Hitbox.IsActive)
            {
                HandleTriger(enemy);
                AdjustEnemyPosition(enemy.Body(), tile.Body());
            }
        }
        private static void HandleTriger(INPC enemy)
        {
            if (enemy is TrapEnemy trap)
            {
                trap.reset();
            }
            if (enemy is RopeEnemy ropeenemy)
            {
                ropeenemy.reset();
            }
        }
        private static void AdjustEnemyPosition(IEnemyPhysicsObject enemy, ITilePhysicsObject tile)
        {
            GeneralConstants.Orientation side = enemy.Hitbox.Side(tile.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        enemy.PosY = tile.Hitbox.PosY - (tile.Hitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        enemy.PosY = tile.Hitbox.PosY + (tile.Hitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        enemy.PosX = tile.Hitbox.PosX - (tile.Hitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        enemy.PosX = tile.Hitbox.PosX + (tile.Hitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
            }
        }
    }
}
