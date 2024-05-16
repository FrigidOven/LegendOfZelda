using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.WeaponSprites.Bomb;
using ZeldaNES.Sprites;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Sprites.Classes.WeaponSprites.Termination;

namespace ZeldaNES.Weapons.Classes.Bomb.States
{
    public class BombExplodingState : IWeaponState
    {
        private Bomb bomb;
        private ISprite sprite;

        public BombExplodingState(Bomb bomb)
        {
            this.bomb = bomb;
            sprite = new BombTerminationSprite(this.bomb);
            bomb.Body().Hitbox.IsActive = true;
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
