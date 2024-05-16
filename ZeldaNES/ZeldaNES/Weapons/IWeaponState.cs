using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.Weapons
{
    public interface IWeaponState
    {
        void Update();
        void Draw();
        void Terminate();
    }
}
