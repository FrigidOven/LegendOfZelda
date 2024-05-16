using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Physics.PhysicsObjects;

namespace ZeldaNES.Doors
{
    public interface IDoor
    {
        public int GetIndex();
        public GeneralConstants.CardinalDirection GetCardinalPosition();
        public int Index { get; set; }
        public int PosX { set; get; }
        public int PosY { set; get; }
        public void Draw();
        public void DrawDebug();

        public Type GetLinkingType();
        public void Update();
        public IDoorPhysicsObject Body();
    }
}
