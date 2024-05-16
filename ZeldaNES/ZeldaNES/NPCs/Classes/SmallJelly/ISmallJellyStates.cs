using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.NPCs.Classes.SmallJelly
{
    public interface ISmallJellyStates
    {
        void Update();
        void Draw();
        void SmallJellyMovingUp();
        void SmallJellyMovingLeft();
        void SmallJellyMovingRight();
        void SmallJellyMovingDown();

    }
}
