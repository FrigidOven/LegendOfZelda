using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.NPCs.Classes.Rope
{
    public interface IRopeState
    {
        void Update();
        void Draw();

        int GetDirection();
        void Chase();
        void Reset();
    }
}
