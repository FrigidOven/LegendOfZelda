using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Physics;
using ZeldaNES.Physics.PhysicsObjects;
using ZeldaNES.Screens;

namespace ZeldaNES.Tiles
{
    public interface ITile : IStaticObject
    {
        void Update();
        void Draw();
        bool IsSolid();     
        public int PosX {set; get;}
        public int PosY { set; get; }

        public ITilePhysicsObject Body();

    }
}
