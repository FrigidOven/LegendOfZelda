using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.NPCs.Classes.WallMaster
{
    public interface IWallMasterState
    {
        void Update();

        void Draw();

    }
}