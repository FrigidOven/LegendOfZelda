using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.EnemySprites.BossSprites.Dodongo;
using ZeldaNES.Sprites;

namespace ZeldaNES.NPCs.Classes.Dodongo.States
{
    public class DodongoWalkingUpState : IDodongoState
    {
        DodongoEnemy dodongo;
        ISprite sprite;
        public DodongoWalkingUpState(DodongoEnemy dodongo)
        {
            this.dodongo = dodongo;
            sprite = new DodongoWalkingUpSprite(dodongo);
        }

        public void Update()
        {
            dodongo.PosY -= BossConstants.DodongoWalkSpeed;
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void EatBomb()
        {
            dodongo.SetDodongoState(new DodongoEatingBombUpState(dodongo));
        }
        public void WalkForwards()
        {
            // do nothing, already walking;
        }
        public void TurnLeft()
        {
            dodongo.SetDodongoState(new DodongoWalkingLeftState(dodongo));
        }
        public void TurnRight()
        {
            dodongo.SetDodongoState(new DodongoWalkingRightState(dodongo));
        }
    }
}
