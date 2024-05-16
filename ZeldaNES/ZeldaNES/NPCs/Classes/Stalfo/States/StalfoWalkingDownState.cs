using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.Stalfo.States;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites.Classes.ItemSprites;

namespace ZeldaNES.NPCs.Classes.Stalfo.States
{
    internal class StalfoWalkingDownState : IStalfoStates
    {
        StalfoEnemy stalfoReference;
        private ISprite sprite;
        public void Update()
        {
            stalfoReference.PosY += EnemyConstants.StalfoMovementSpeed;
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void StalfoWalkingDown()
        {
            stalfoReference.SetStalfoState(new StalfoWalkingDownState(stalfoReference));
        }
        public void StalfoWalkingUp()
        {
            stalfoReference.SetStalfoState(new StalfoWalkingUpState(stalfoReference));
        }
        public void StalfoWalkingLeft()
        {
            stalfoReference.SetStalfoState(new StalfoWalkingLeftState(stalfoReference));
        }
        public void StalfoWalkingRight()
        {
            stalfoReference.SetStalfoState(new StalfoWalkingRightState(stalfoReference));
        }

        public StalfoWalkingDownState(StalfoEnemy stalfo)
        {
            this.stalfoReference = stalfo;
            this.sprite = new StalfoSprite(stalfo);
        }
    }
}
