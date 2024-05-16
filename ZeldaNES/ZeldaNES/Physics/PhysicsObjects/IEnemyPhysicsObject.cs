using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.Hitboxes;

namespace ZeldaNES.Physics.PhysicsObjects
{
    public interface IEnemyPhysicsObject
    {
        int PosX { get; set; }
        int PosY { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        bool IsTakingDamage { get; set; }
        IHitbox Hitbox { get; set; }
    }
}
