using System.Collections.Generic;
using System.Diagnostics;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Screens.Classes;
using System;
using ZeldaNES.NPCs.Classes.Rope;
using ZeldaNES.NPCs.Classes.Trap;
using ZeldaNES.NPCs.Classes.WallMaster;
namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class PlayerEnemyPhysicsHandler
    {
        public static void HandlePhysics(List<ILink> players, List<INPC> enemies, IRegion region)
        {
            foreach (var player in players)
            {
                HandleTriger4D(player, enemies);//trap for now  
                HandleTriger2D(player, enemies);//rope for now
                if (player.Body().SwordHitbox.IsActive)
                {
                    HandleActivePhysics(players, enemies);
                    return;
                }
            
                HandleInactivePhysics(players, enemies, region);
            }
           
        }
        private static bool IsSwordTouching(IPlayerPhysicsObject player, IEnemyPhysicsObject enemy)
        {
            return player.SwordHitbox.Intersects(enemy.Hitbox);
        }
        private static bool IsBodyTouching(ILink player, INPC enemy)
        {
            return player.Body().PlayerHitbox.Intersects(enemy.Body().Hitbox);
        }
        private static bool IsInvisibleLineTouching4D(ILink player, INPC enemy)
        {
            return Math.Abs(player.Body().PosX - enemy.Body().PosX) < 4 || Math.Abs(player.Body().PosY - enemy.Body().PosY) < 4;
        }
        private static bool IsInvisibleLineTouching2D(ILink player, INPC enemy)
        {
            return Math.Abs(player.Body().PosY - enemy.Body().PosY) < 4;
        }
        private static void HandleActivePhysics(List<ILink> players, List<INPC> enemies)
        {
            foreach (var player in players)
            {
                foreach (var enemy in enemies)
                {
                    if (!IsSwordTouching(player.Body(), enemy.Body()) || enemy.Body().IsTakingDamage)
                    {
                        continue;
                    }
                    enemy.Body().Health -= player.Damage;
                    AdjustPosition(enemy.Body(), player.Body());
                    SoundManager.SoundManager.Instance.EnemyDamaged.CreateInstance().Play();
                }
            }
        }
        private static void HandleInactivePhysics(List<ILink> players, List<INPC> enemies, IRegion region)
        {
            foreach (var player in players)
            {
                foreach (var enemy in enemies)
                {
                    if (!IsBodyTouching(player, enemy))
                    {
                        continue;
                    }
                    if (!player.IsTakingDamage)
                    {
                        wallmaster(player, enemies, region);
                        player.Health -= enemy.Body().Damage;
                        AdjustPosition(player, enemy.Body());
                        RopeStopchasing(player, enemies);
                    }
                }
            }
        }
        private static void AdjustPosition(IEnemyPhysicsObject enemy, IPlayerPhysicsObject player)
        {
            GeneralConstants.Orientation side = enemy.Hitbox.Side(player.SwordHitbox);

            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        enemy.PosY = player.SwordHitbox.PosY - (player.SwordHitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        enemy.PosY = player.SwordHitbox.PosY + (player.SwordHitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        enemy.PosX = player.SwordHitbox.PosX - (player.SwordHitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        enemy.PosX = player.SwordHitbox.PosX + (player.SwordHitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
            }
        }
        private static void HandleTriger4D(ILink player, List<INPC> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is TrapEnemy trap)
                {
                    if (IsInvisibleLineTouching4D(player, trap) && !trap.hasTriggered())
                    {
                        if (player.Body().PosY > trap.Body().PosY && Math.Abs(player.Body().PosX - trap.Body().PosX) < 16 )
                        {
                            trap.Triggerup();

                        }
                        else if (player.Body().PosY < trap.Body().PosY && Math.Abs(player.Body().PosX - trap.Body().PosX) <16 )
                        {
                            trap.Triggerdown();

                        }
                        else if (player.Body().PosX > trap.Body().PosX && Math.Abs(player.Body().PosY - trap.Body().PosY) < 16)
                        {
                            trap.Triggerright();
                        }
                        else if (player.Body().PosX < trap.Body().PosX && Math.Abs(player.Body().PosY - trap.Body().PosY) < 16)
                        {
                            trap.Triggerleft();
                        }
                    }
                }
            }
        }
        private static void HandleTriger2D(ILink player, List<INPC> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is RopeEnemy ropeenemy)
                {
                    if (IsInvisibleLineTouching2D(player, ropeenemy) && !ropeenemy.triggerbool)
                    {
                        if (player.Body().PosX >= ropeenemy.Body().PosX)
                        {
                            ropeenemy.triggerright();
                        }
                        else if (player.Body().PosX < ropeenemy.Body().PosX)
                        {
                            ropeenemy.triggerleft();
                        }
                    }
                }
            }
        }
        private static void RopeStopchasing(ILink player, List<INPC> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is RopeEnemy ropeenemy)
                {
                    ropeenemy.reset();
                }
            }
        }
        public static void wallmaster(ILink player, List<INPC> enemies, IRegion region)
        {
            foreach (var enemy in enemies)
            {
                if (enemy is WallMasterEnemy wallmaster)
                {
                    region.NextAreaIndex = 0;
                }
            }
        }
        private static void AdjustPosition(ILink player, IEnemyPhysicsObject enemy)
        {
            GeneralConstants.Orientation side = player.Body().PlayerHitbox.Side(enemy.Hitbox);
            player.KnockBack(side, (16 * GeneralConstants.ImageScale) / 2);

            /**
             * Discovery: This switch block is no longer needed if we have knockback, the physics is smoother without it.
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        player.PosY = enemy.Hitbox.PosY - (enemy.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        break;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        player.PosY = enemy.Hitbox.PosY + (enemy.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        break;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        player.PosX = enemy.Hitbox.PosX - (enemy.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        break;
                    }
                default:
                    {
                        player.PosX = enemy.Hitbox.PosX + (enemy.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        break;
                    }
            }
            */
        }
    }
}
