using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Players.Link;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.Bomb;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class WeaponPlayerPhysicsHandler
    {

        public static void HandlePhysics(List<IWeapon> weapons, List<ILink> players)
        {
            foreach (var weapon in weapons)
            {
                foreach (var player in players)
                {
                    if (IsTouching(weapon.Body(), player.Body()) && weapon.Body().Hitbox.IsActive)
                    {
                        weapon.Terminate();
                        player.Health -= weapon.Body().Damage;
                        player.IsTakingDamage = true;
                        if (weapon is not Bomb)
                        {
                            weapon.Body().Hitbox.IsActive = false;
                        }
                        AdjustPlayerPosition(player, weapon.Body());
                    }
                }
            }
        }
        private static bool IsTouching(IWeaponPhysicsObject weapon, IPlayerPhysicsObject player)
        {
            return weapon.Hitbox.IsActive && weapon.Hitbox.Intersects(player.PlayerHitbox);
        }
        private static void AdjustPlayerPosition(ILink player, IWeaponPhysicsObject weapon)
        {
            GeneralConstants.Orientation side = player.Body().PlayerHitbox.Side(weapon.Hitbox);
            player.KnockBack(side, (16 * GeneralConstants.ImageScale) / 2);
            /**
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        player.PosY = weapon.Hitbox.PosY - (weapon.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        player.PosY = weapon.Hitbox.PosY + (weapon.Hitbox.Height + player.PlayerHitbox.Height) / 2 - player.PlayerHitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        player.PosX = weapon.Hitbox.PosX - (weapon.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        player.PosX = weapon.Hitbox.PosX + (weapon.Hitbox.Width + player.PlayerHitbox.Width) / 2 - player.PlayerHitbox.OffsetX;
                        return;
                    }
            }
            */
        }
    }
}
