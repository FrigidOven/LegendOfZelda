using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics.Hitboxes;
using ZeldaNES.Players.Link;

namespace ZeldaNES.Physics.PhysicsObjects
{
    public interface IPlayerPhysicsObject
    {
        int PosX { get; set; }
        int PosY { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
        bool IsTakingDamage { get; set; }
        IHitbox PlayerHitbox { get; set; }
        IHitbox SwordHitbox { get; set; }
    }
}
