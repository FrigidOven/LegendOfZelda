using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.SmallJelly.States;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites.Classes.ItemSprites;

namespace ZeldaNES.NPCs.Classes.SmallJelly.States
{
    internal class SmallJellyFrozenState : ISmallJellyStates
    {
        SmallJellyEnemy smallJellyReference;
        ISprite sprite;
        public void Update()
        {
            //smallJellyReference.PosY += EnemyConstants.SmallJellyMovementSpeed;
            //sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void SmallJellyMovingDown()
        {
            smallJellyReference.SetSmallJellyState(new SmallJellyMovingDownState(smallJellyReference));
        }
        public void SmallJellyMovingUp()
        {
            smallJellyReference.SetSmallJellyState(new SmallJellyMovingUpState(smallJellyReference));
        }
        public void SmallJellyMovingLeft()
        {
            smallJellyReference.SetSmallJellyState(new SmallJellyMovingLeftState(smallJellyReference));
        }
        public void SmallJellyMovingRight()
        {
            smallJellyReference.SetSmallJellyState(new SmallJellyMovingRightState(smallJellyReference));
        }

        public SmallJellyFrozenState(SmallJellyEnemy smallJelly)
        {
            this.smallJellyReference = smallJelly;
            this.sprite = new SmallJellySprite(smallJelly);
        }
    }
}
