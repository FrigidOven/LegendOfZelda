using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Doors1;
using ZeldaNES.Weapons;
using ZeldaNES.Doors1.ShutDoor;
using ZeldaNES.Regions;
using ZeldaNES.NPCs.Classes.Rope;
using ZeldaNES.NPCs.Classes.Trap;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class EnemyDoorPhysicsHandler
    {
        public static void HandlePhysics(List<INPC> enemies, List<IDoor> doors, IRegion region)
        {
            if(enemies.Count == 0)
            {
                foreach(var door in doors)
                {
                    if(!door.Body().Hitbox.IsActive && door is ShutDoor)
                    {
                        door.Open();    
                        SoundManager.SoundManager.Instance.DoorUnlock.CreateInstance().Play();
                        OpenCorrespondingDoor(door, region);
                    }
                }
                return;
            }
            foreach (var enemy in enemies)
            {

                foreach (var door in doors)
                {
                    if (IsTouching(enemy.Body(), door.Body()))
                    {
                        HandleTriger(enemy);
                    }
                }
            }

            foreach (var enemy in enemies)
            {
                foreach (var door in doors)
                {
                    if (IsTouching(enemy.Body(), door.Body()))
                    {
                        AdjustEnemyPosition(enemy.Body(), door.Body());
                    }
                }
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
        private static void OpenCorrespondingDoor(IDoor door, IRegion region)
        {
            // get the doors of the next area
            List<IDoor> doors = region.Areas[door.Index].Doors;

            for (int i = 0; i < doors.Count; i++)
            {
                if (doors[i].Index == region.AreaIndex)
                {
                    doors[i].Open();
                    // break since there is only one door that links to the current door
                    break;
                }
            }
        }
        private static bool IsTouching(IEnemyPhysicsObject enemy, IDoorPhysicsObject door)
        {
            return enemy.Hitbox.Intersects(door.Hitbox);
        }
        private static void AdjustEnemyPosition(IEnemyPhysicsObject enemy, IDoorPhysicsObject door)
        {
            GeneralConstants.Orientation side = enemy.Hitbox.Side(door.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        enemy.PosY = door.Hitbox.PosY - (door.Hitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        enemy.PosY = door.Hitbox.PosY + (door.Hitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        enemy.PosX = door.Hitbox.PosX - (door.Hitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        enemy.PosX = door.Hitbox.PosX + (door.Hitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
            }
        }
    }
}
