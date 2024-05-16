using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;

namespace ZeldaNES.Weapons
{
    public interface IWeaponUser
    {
        int PosX { get; }
        int PosY { get; }
        bool IsFriendly { get; }
        void SetWeaponFactory(WeaponFactory weaponfactory);
    }
}
