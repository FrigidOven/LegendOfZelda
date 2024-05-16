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
    public class DodongoEatingBombUpState : IDodongoState
    {
        DodongoEnemy dodongo;
        ISprite sprite;
        public DodongoEatingBombUpState(DodongoEnemy dodongo)
        {
            this.dodongo = dodongo;
            sprite = new DodongoEatingBombUpSprite(dodongo);
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
            dodongo.SetDodongoState(new DodongoWalkingUpState(dodongo));
        }
        public void TurnLeft()
        {
            dodongo.SetDodongoState(new DodongoEatingBombLeftState(dodongo));
        }
        public void TurnRight()
        {
            dodongo.SetDodongoState(new DodongoEatingBombRightState(dodongo));
        }
    }
}
