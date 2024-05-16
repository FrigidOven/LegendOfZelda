using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.EnemySprites.BossSprites.Dodongo;
using ZeldaNES.Sprites;

namespace ZeldaNES.NPCs.Classes.Dodongo.States
{
    public class DodongoEatingBombRightState : IDodongoState
    {
        DodongoEnemy dodongo;
        ISprite sprite;
        public DodongoEatingBombRightState(DodongoEnemy dodongo)
        {
            this.dodongo = dodongo;
            sprite = new DodongoEatingBombRightSprite(dodongo);
        }

        public void Update()
        {
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void EatBomb()
        {
            // do nothing, already eating bomb
        }
        public void WalkForwards()
        {
            dodongo.SetDodongoState(new DodongoWalkingRightState(dodongo));
        }
        public void TurnLeft()
        {
            dodongo.SetDodongoState(new DodongoEatingBombUpState(dodongo));
        }
        public void TurnRight()
        {
            dodongo.SetDodongoState(new DodongoEatingBombDownState(dodongo));
        }
    }
}
