using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.NPCs.Classes.Keese
{
    public interface IKeeseStates
    {
        void Update();
        void Draw();
        void KeeseFlyingUp();
        void KeeseFlyingUpAndLeft();
        void KeeseFlyingUpAndRight();
        void KeeseFlyingLeft();
        void KeeseFlyingRight();
        void KeeseFlyingDown();
        void KeeseFlyingDownAndLeft();
        void KeeseFlyingDownAndRight();
        void KeeseNotFlying();
    }
}
