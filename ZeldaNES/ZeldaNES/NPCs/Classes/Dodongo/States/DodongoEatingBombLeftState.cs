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
    public class DodongoEatingBombLeftState : IDodongoState
    {
        DodongoEnemy dodongo;
        ISprite sprite;
        public DodongoEatingBombLeftState(DodongoEnemy dodongo)
        {
            this.dodongo = dodongo;
            sprite = new DodongoEatingBombLeftSprite(dodongo);
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
            dodongo.SetDodongoState(new DodongoWalkingLeftState(dodongo));
        }
        public void TurnLeft()
        {
            dodongo.SetDodongoState(new DodongoEatingBombDownState(dodongo));
        }
        public void TurnRight()
        {
            dodongo.SetDodongoState(new DodongoEatingBombUpState(dodongo));
        }
    }
}
