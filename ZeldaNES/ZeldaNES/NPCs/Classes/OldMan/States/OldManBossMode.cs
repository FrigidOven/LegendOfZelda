using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Factories;

namespace ZeldaNES.NPCs.Classes.OldMan.States
{
    internal class OldManBossMode : IOldManState
    {
        OldManNPC self;
        

        private int directionTimer;
        public OldManBossMode(OldManNPC oldman) 
        {
            this.self = oldman;
            directionTimer = 15;
        }

        public void Update() 
        {
            
        }

        public void Draw() { }
    }
}
