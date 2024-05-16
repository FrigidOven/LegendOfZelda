using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;

namespace ZeldaNES.NPCs.Classes.Trap.States
{
    internal class TrapNormalState : ITrapStates
    {
        TrapEnemy reference;
//        private ISprite sprite;


        public TrapNormalState(TrapEnemy trap)
        {
            this.reference = trap;
            //reference.sprite = new TrapSprite(trap);
        }

        public void Draw()
        {
            //reference.sprite.Draw();
        }

        public void Update()
        {
            if (reference.triggerup)
            {
                reference.PosY += EnemyConstants.ChasingSpeed;
                reference.changingroomcounter++;
            }
            else if (reference.triggerdown)
            {
                reference.PosY -= EnemyConstants.ChasingSpeed;
                reference.changingroomcounter++;
            }
            else if (reference.triggerleft)
            {
                reference.PosX -= EnemyConstants.ChasingSpeed;
                reference.changingroomcounter++;
            }
            else if (reference.triggerright)
            {
                reference.PosX += EnemyConstants.ChasingSpeed;
                reference.changingroomcounter++;
            }
            if (reference.changingroomcounter > 16 * 3 * 12)
            {
                reference.triggerup = false;
                reference.triggerdown = false;
                reference.triggerleft = false;
                reference.triggerright = false;
                reference.changingroomcounter = 0;
            }
        }
    }
}
