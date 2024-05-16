using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.NPCs.Classes.WallMaster;

namespace ZeldaNES.NPCs.Classes.WallMaster.States
{
    internal class WallMasterFrozenState : IWallMasterState
    {
        WallMasterEnemy reference;
        public WallMasterFrozenState(WallMasterEnemy wallmaster) {
            this.reference = wallmaster;
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Draw() {
            reference.Draw();
        }
    }
}
