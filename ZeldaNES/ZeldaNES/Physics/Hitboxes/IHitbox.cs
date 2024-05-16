using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Physics.Hitboxes
{
    public interface IHitbox
    {
        bool IsActive { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }
        int OffsetX { get; set; }
        int OffsetY { get; set;  }
        int Width { get; set; }
        int Height { get; set; }
        Rectangle Bounds { get; }
        bool Intersects(IHitbox hitbox);
        GeneralConstants.Orientation Side(IHitbox hitbox);
    }
}
