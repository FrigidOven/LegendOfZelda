using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.NPCs.Classes.BigJelly.States;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites.Classes.ItemSprites;

namespace ZeldaNES.NPCs.Classes.BigJelly.States
{
    internal class BigJellyMovingDownState : IBigJellyStates
    {
        BigJellyEnemy bigJellyReference;
        ISprite sprite;
        public void Update()
        {
            bigJellyReference.PosY += EnemyConstants.BigJellyMovementSpeed;
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void BigJellyMovingDown()
        {
            bigJellyReference.SetBigJellyState(new BigJellyMovingDownState(bigJellyReference));
        }
        public void BigJellyMovingUp()
        {
            bigJellyReference.SetBigJellyState(new BigJellyMovingUpState(bigJellyReference));
        }
        public void BigJellyMovingLeft()
        {
            bigJellyReference.SetBigJellyState(new BigJellyMovingLeftState(bigJellyReference));
        }
        public void BigJellyMovingRight()
        {
            bigJellyReference.SetBigJellyState(new BigJellyMovingRightState(bigJellyReference) );
        }

        public BigJellyMovingDownState(BigJellyEnemy bigJelly)
        {
            this.bigJellyReference = bigJelly;
            this.sprite = new BigJellySprite(bigJelly);
        }
    }
}
