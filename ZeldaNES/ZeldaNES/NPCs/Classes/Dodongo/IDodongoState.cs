using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.NPCs.Classes.Dodongo
{
    public interface IDodongoState
    {
        void Update();
        void Draw();

        void EatBomb();
        void WalkForwards();
        void TurnLeft();
        void TurnRight();
    }
}
