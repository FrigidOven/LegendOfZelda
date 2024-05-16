using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeldaNES.NPCs.Classes.OldMan.States
{
    internal class OldManPeacefulMode : IOldManState
    {
        OldManNPC self;
        public OldManPeacefulMode(OldManNPC oldman)
        {
            this.self = oldman;
        }

        public void Update() { }

        public void Draw() { }
    }
}
