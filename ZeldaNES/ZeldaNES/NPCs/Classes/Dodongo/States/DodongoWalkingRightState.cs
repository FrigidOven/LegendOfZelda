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
    public class DodongoWalkingRightState : IDodongoState
    {
        DodongoEnemy dodongo;
        ISprite sprite;
        public DodongoWalkingRightState(DodongoEnemy dodongo)
        {
            this.dodongo = dodongo;
            sprite = new DodongoWalkingRightSprite(dodongo);
        }

        public void Update()
        {
            dodongo.PosX += BossConstants.DodongoWalkSpeed;
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void EatBomb()
        {
            dodongo.SetDodongoState(new DodongoEatingBombRightState(dodongo));
        }
        public void WalkForwards()
        {
            // do nothing, already walking;
        }
        public void TurnLeft()
        {
            dodongo.SetDodongoState(new DodongoWalkingUpState(dodongo));
        }
        public void TurnRight()
        {
            dodongo.SetDodongoState(new DodongoWalkingDownState(dodongo));
        }
    }
}
