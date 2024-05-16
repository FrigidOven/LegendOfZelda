using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.NPCs.Classes.BigJelly
{
    public interface IBigJellyStates
    {
        void Update();
        void Draw();
        void BigJellyMovingUp();
        void BigJellyMovingLeft();
        void BigJellyMovingRight();
        void BigJellyMovingDown();

    }
}
