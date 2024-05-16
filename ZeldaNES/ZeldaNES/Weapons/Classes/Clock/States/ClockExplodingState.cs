using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.WeaponSprites.Bomb;
using ZeldaNES.Sprites;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Sprites.Classes.WeaponSprites.Termination;

namespace ZeldaNES.Weapons.Classes.Clock.States
{
    public class ClockExplodingState : IWeaponState
    {
        private Clock clock;
        private ISprite sprite;

        public ClockExplodingState(Clock clock)
        {
            this.clock = clock;
            sprite = new BombTerminationSprite(this.clock);
            clock.Body().Hitbox.IsActive = true;
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
            // do nothing, bomb has already been terminated.
        }
    }
}
