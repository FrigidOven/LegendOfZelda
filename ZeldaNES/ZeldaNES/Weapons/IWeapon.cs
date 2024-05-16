using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Physics.PhysicsObjects.Classes;
using ZeldaNES.Screens;

namespace ZeldaNES.Weapons
{
    public interface IWeapon
    {
        void Update();
        void Draw();
        int PosX { get; set; }
        int PosY { get; set; }
        bool ShouldDelete {  get; set; }
        IWeaponPhysicsObject Body();
        void Terminate();
    }
}
