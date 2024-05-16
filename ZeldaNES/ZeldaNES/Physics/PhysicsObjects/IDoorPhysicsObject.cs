using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.Hitboxes;

namespace ZeldaNES.Physics.PhysicsObjects
{
    public interface IDoorPhysicsObject
    {
        int PosX { get; set; }
        int PosY { get; set; }
        bool IsBeingTouched { get; set; }
        IHitbox Hitbox { get; set; }
    }
}
