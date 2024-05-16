using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.EnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites;
using ZeldaNES.Sprites.Classes.EnemySprites.DungeonEnemySprites.Keese;

namespace ZeldaNES.NPCs.Classes.Keese.States
{
    internal class KeeseFlyingRightState: IKeeseStates
    {
        KeeseEnemy keeseReference;
        ISprite sprite;
        public void Update()
        {
            keeseReference.PosX += EnemyConstants.KeeseMovementSpeed;
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void KeeseFlyingUp()
        {
            keeseReference.SetState(new KeeseFlyingUpState(keeseReference));
        }
        public void KeeseFlyingUpAndLeft()
        {
        }
        public void KeeseFlyingUpAndRight()
        {
            keeseReference.SetState(new KeeseFlyingUpAndRightState(keeseReference));

        }
        public void KeeseFlyingLeft()
        {
            keeseReference.SetState(new KeeseFlyingLeftState(keeseReference));

        }
        public void KeeseFlyingRight()
        {
            keeseReference.SetState(new KeeseFlyingRightState(keeseReference));

        }
        public void KeeseFlyingDown()
        {
            keeseReference.SetState(new KeeseFlyingDownState(keeseReference));

        }
        public void KeeseFlyingDownAndLeft()
        {
            keeseReference.SetState(new KeeseFlyingDownAndLeftState(keeseReference));

        }
        public void KeeseFlyingDownAndRight()
        {
            keeseReference.SetState(new KeeseFlyingDownAndRightState(keeseReference));

        }
        public void KeeseNotFlying()
        {
            keeseReference.SetState(new KeeseNotFlyingState(keeseReference));

        }
        public  KeeseFlyingRightState(KeeseEnemy keese) {
            this.keeseReference = keese;
            this.sprite = new KeeseFlyingSprite(keese);
        }

    }
}
