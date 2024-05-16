using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.NPCs.Classes.WallMaster;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;

namespace ZeldaNES.NPCs.Classes.WallMaster.States
{
    internal class WallMasterNormalState : IWallMasterState
    {
        WallMasterEnemy reference;
        //private ISprite sprite;

        public WallMasterNormalState(WallMasterEnemy wallmaster) {
            this.reference = wallmaster;
            //this.sprite = new WallMasterSprite(reference);
        }

        public void Update()
        {
        }

        public void Draw()
        {
            reference.Draw();
        }
    }
}
