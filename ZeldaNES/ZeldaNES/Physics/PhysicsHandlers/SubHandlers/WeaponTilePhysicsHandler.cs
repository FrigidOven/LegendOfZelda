using System.Collections.Generic;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Tiles;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.Bomb;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class WeaponTilePhysicsHandler
    {


        public static void HandlePhysics(List<IWeapon> weapons, List<ITile> tiles)
        {
            foreach (var weapon in weapons)
            {
                foreach (var tile in tiles)
                {
                    if (IsTouching(weapon.Body(), tile.Body()) && weapon.Body().Hitbox.IsActive)
                    {
                        weapon.Terminate();
                        if (weapon is not Bomb)
                        {
                            weapon.Body().Hitbox.IsActive = false;
                        }
                    }
                }
            }
        }
        private static bool IsTouching(IWeaponPhysicsObject weapon, ITilePhysicsObject tile)
        {
            return tile.Hitbox.IsActive && (weapon.Hitbox.Intersects(tile.Hitbox));
        }
        private static void AdjustWeaponPosition(IWeaponPhysicsObject weapon, ITilePhysicsObject tile)
        {
            GeneralConstants.Orientation side = weapon.Hitbox.Side(tile.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        weapon.PosY = tile.Hitbox.PosY - (tile.Hitbox.Height + weapon.Hitbox.Height) / 2 - weapon.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        weapon.PosY = tile.Hitbox.PosY + (tile.Hitbox.Height + weapon.Hitbox.Height) / 2 - weapon.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        weapon.PosX = tile.Hitbox.PosX - (tile.Hitbox.Width + weapon.Hitbox.Width) / 2 - weapon.Hitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        weapon.PosX = tile.Hitbox.PosX + (tile.Hitbox.Width + weapon.Hitbox.Width) / 2 - weapon.Hitbox.OffsetX;
                        return;
                    }
            }
        }
    }
}
