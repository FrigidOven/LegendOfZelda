using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.WeaponSprites.Bomb;

namespace ZeldaNES.Weapons.Classes.Bomb.States
{
    public class BombTickingState : IWeaponState
    {
        private Bomb bomb;
        private ISprite sprite;

        public BombTickingState(Bomb bomb)
        {
            this.bomb = bomb;
            sprite = new BombTickingSprite(this.bomb);
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
            bomb.state = new BombExplodingState(bomb);
            SoundManager.SoundManager.Instance.BombBlowingUp.CreateInstance().Play();
        }
    }
}
