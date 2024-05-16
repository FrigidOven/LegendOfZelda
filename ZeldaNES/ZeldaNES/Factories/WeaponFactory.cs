using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;
using ZeldaNES.Regions;
using ZeldaNES.Screens;
using ZeldaNES.Screens.Classes;
using ZeldaNES.Weapons;
using ZeldaNES.Weapons.Classes.Bomb;
using ZeldaNES.Weapons.Classes.EnergyBall;
using ZeldaNES.Weapons.Classes.Fire;
using ZeldaNES.Weapons.Classes.MetalArrow;
using ZeldaNES.Weapons.Classes.MetalBoomerang;
using ZeldaNES.Weapons.Classes.WoodenArrow;
using ZeldaNES.Weapons.Classes.WoodenBoomerang;
using ZeldaNES.Weapons.Classes.Clock;
using static ZeldaNES.Game_Constants.GeneralConstants;

namespace ZeldaNES.Factories
{
    public class WeaponFactory
    {
        private IRegion region;

        public WeaponFactory(IRegion region)
        {
            this.region = region;
        }
        public void MakeNewBomb(int posX, int posY)
        {
            region.Areas[region.AreaIndex].AddHostileWeapon(new Bomb(posX, posY));
            region.Areas[region.AreaIndex].AddFriendlyWeapon(new Bomb(posX, posY));
        }

        public void MakeNewBomb(int posX, int posY, IWeaponUser user)
        {
            region.Areas[region.AreaIndex].AddHostileWeapon(new Bomb(posX, posY, user));
            region.Areas[region.AreaIndex].AddFriendlyWeapon(new Bomb(posX, posY, user));
        }



        public void MakeNewFire(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (owner.IsFriendly)
            {
                region.Areas[region.AreaIndex].AddFriendlyWeapon(new Fire(posX, posY, orientation, owner));
                return;
            }
            region.Areas[region.AreaIndex].AddHostileWeapon(new Fire(posX, posY, orientation, owner));
        }
        public void MakeNewEnergyBall(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (!owner.IsFriendly) {
               region.Areas[region.AreaIndex].AddHostileWeapon( new EnergyBall(posX, posY, orientation));
            }
        }
        public void MakeNewWoodenArrow(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (owner.IsFriendly)
            {
                region.Areas[region.AreaIndex].AddFriendlyWeapon(new WoodenArrow(posX, posY, orientation, owner));
                return;
            }
            region.Areas[region.AreaIndex].AddHostileWeapon(new WoodenArrow(posX, posY, orientation, owner));
        }
        public void MakeNewMetalArrow(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (owner.IsFriendly)
            {
                region.Areas[region.AreaIndex].AddFriendlyWeapon(new MetalArrow(posX, posY, orientation, owner));
                return;
            }
            region.Areas[region.AreaIndex].AddHostileWeapon(new MetalArrow(posX, posY, orientation, owner));
        }
        public void MakeNewWoodenBoomerang(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (owner.IsFriendly)
            {
                region.Areas[region.AreaIndex].AddFriendlyWeapon(new WoodenBoomerang(posX, posY, orientation, owner));
                return;
            }
            region.Areas[region.AreaIndex].AddHostileWeapon(new WoodenBoomerang(posX, posY, orientation, owner));
        }
        public void MakeNewMetalBoomerang(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (owner.IsFriendly)
            {
                region.Areas[region.AreaIndex].AddFriendlyWeapon(new MetalBoomerang(posX, posY, orientation, owner));
                return;
            }
            region.Areas[region.AreaIndex].AddHostileWeapon(new MetalBoomerang(posX, posY, orientation, owner));
        }


        public void MakeNewClock(int posX, int posY, GeneralConstants.Orientation orientation, IWeaponUser owner)
        {
            if (owner.IsFriendly)
            {
                region.Areas[region.AreaIndex].AddFriendlyWeapon(new Clock(posX, posY));
            }
        }
    }
}
