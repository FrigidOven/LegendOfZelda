using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.WeaponSprites.Bomb;

namespace ZeldaNES.Weapons.Classes.Clock.States
{
    public class ClockTickingState : IWeaponState
    {
        private Clock clock;
        private ISprite sprite;

        public ClockTickingState(Clock clock)
        {
            this.clock = clock;
            sprite = new ClockTickingSprite(this.clock);
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            clock.state = new ClockExplodingState(clock);
            SoundManager.SoundManager.Instance.BombBlowingUp.CreateInstance().Play();
        }
    }
}
