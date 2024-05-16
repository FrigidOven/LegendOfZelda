using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.Bomb;

namespace ZeldaNES.Physics.PhysicsHandlers.SubHandlers
{
    public static class WeaponEnemyPhysicsHandler
    {
    
        public static void HandlePhysics(List<IWeapon> weapons, List<INPC> enemies)
        {
            foreach(var weapon in weapons)
            {
                
                foreach (var enemy in enemies)
                {
                    if(IsTouching(weapon.Body(), enemy.Body()) && weapon.Body().Hitbox.IsActive)
                    {
                        weapon.Terminate();
                        enemy.Body().Health -= weapon.Body().Damage;
                        if (weapon is not Bomb)
                        {
                            weapon.Body().Hitbox.IsActive = false;
                        };
                        //AdjustEnemyPosition(enemy.Body(), weapon.Body());
                    }
                }
            }
        }
        private static bool IsTouching(IWeaponPhysicsObject weapon, IEnemyPhysicsObject enemy)
        {
            return weapon.Hitbox.IsActive && weapon.Hitbox.Intersects(enemy.Hitbox);
        }
        private static void AdjustEnemyPosition(IEnemyPhysicsObject enemy, IWeaponPhysicsObject weapon)
        {
            GeneralConstants.Orientation side = enemy.Hitbox.Side(weapon.Hitbox);
            switch (side)
            {
                case GeneralConstants.Orientation.Up:
                    {
                        enemy.PosY = weapon.Hitbox.PosY - (weapon.Hitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Down:
                    {
                        enemy.PosY = weapon.Hitbox.PosY + (weapon.Hitbox.Height + enemy.Hitbox.Height) / 2 - enemy.Hitbox.OffsetY;
                        return;
                    }
                case GeneralConstants.Orientation.Left:
                    {
                        enemy.PosX = weapon.Hitbox.PosX - (weapon.Hitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
                default:
                    {
                        enemy.PosX = weapon.Hitbox.PosX + (weapon.Hitbox.Width + enemy.Hitbox.Width) / 2 - enemy.Hitbox.OffsetX;
                        return;
                    }
            }
        }
    }
}
