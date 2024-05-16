using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Weapons;

namespace ZeldaNES.NPCs.Classes.Goriya
{
    public interface IGoriyaStates 
    {
        void Update();
        void Draw();
        GeneralConstants.Orientation GetNormal();
        void GoriyaWalkingLeft();
        void GoriyaWalkingRight();
        void GoriyaWalkingUp();
        void GoriyaWalkingDown();
        void GoriyaThrowingBoomerang();
    }
}
