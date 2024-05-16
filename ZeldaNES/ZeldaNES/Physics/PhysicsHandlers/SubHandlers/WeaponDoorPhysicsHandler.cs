using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Achievement;
using ZeldaNES.Doors1;
using ZeldaNES.Doors1.HiddenDoor;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Regions;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.Bomb;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class WeaponDoorPhysicsHandler
    {
        public static void HandlePhysics(List<IWeapon> weapons, List<IDoor> doors, IRegion region)
        {
            foreach (var weapon in weapons)
            {
                foreach (var door in doors)
                {
                    if (IsTouching(weapon.Body(), door.Body()))
                    {
                        if (weapon.Body().Hitbox.IsActive)
                        {
                            weapon.Terminate();
                            if (weapon is not Bomb)
                            {
                                weapon.Body().Hitbox.IsActive = false;
                                continue;
                            }
                            if(!door.Body().Hitbox.IsActive && door is HiddenDoor)
                            {
                                door.Open();
                                OpenCorrespondingDoor(door, region);
                                SoundManager.SoundManager.Instance.Secret.CreateInstance().Play();
                                AchievementTracker.Instance.wallBombed = true;
                            }
                        }
                    }
                }
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
        private static bool IsTouching(IWeaponPhysicsObject weapon, IDoorPhysicsObject door)
        {
            return weapon.Hitbox.Intersects(door.Hitbox);
        }
        private static void AdjustWeaponPosition(IWeaponPhysicsObject weapon, IDoorPhysicsObject door)
        {
            GeneralConstants.Orientation side = weapon.Hitbox.Side(door.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        weapon.PosY = door.Hitbox.PosY - (door.Hitbox.Height + weapon.Hitbox.Height) / 2 - weapon.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        weapon.PosY = door.Hitbox.PosY + (door.Hitbox.Height + weapon.Hitbox.Height) / 2 - weapon.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        weapon.PosX = door.Hitbox.PosX - (door.Hitbox.Width + weapon.Hitbox.Width) / 2 - weapon.Hitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        weapon.PosX = door.Hitbox.PosX + (door.Hitbox.Width + weapon.Hitbox.Width) / 2 - weapon.Hitbox.OffsetX;
                        return;
                    }
            }
        }
    }
}
