using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;

namespace ZeldaNES.NPCs.Classes.Trap.States
{
    internal class TrapFrozenState : ITrapStates
    {
        TrapEnemy reference;
        //private ISprite sprite;

        public TrapFrozenState(TrapEnemy trap) {
            this.reference = trap;
            //this.sprite = new TrapSprite(trap);
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Draw() {
        }
    }
}
