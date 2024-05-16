using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.NPCs.Classes.Stalfo
{
    public interface IStalfoStates
    {
        void Update();
        void Draw();
        void StalfoWalkingUp();
        void StalfoWalkingLeft();
        void StalfoWalkingRight();
        void StalfoWalkingDown();

    }
}
