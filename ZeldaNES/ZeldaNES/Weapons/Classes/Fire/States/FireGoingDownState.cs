using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.WeaponSprites.Fire;
using ZeldaNES.Sprites;

namespace ZeldaNES.Weapons.Classes.Fire.States
{
    public class FireGoingDownState : IWeaponState
    {
        private Fire fire;
        private ISprite sprite;

        public FireGoingDownState(Fire fire)
        {
            this.fire = fire;
            sprite = new FireSprite(fire);
        }
        public void Update()
        {
            sprite.Update();
            fire.PosY = fire.PosY + WeaponConstants.FireSpeed;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            fire.state = new FireTerminationState(fire);
        }
    }
}
