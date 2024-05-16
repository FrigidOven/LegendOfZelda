using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.WeaponSprites.Fire;
using ZeldaNES.Sprites;
using ZeldaNES.Game_Constants;

namespace ZeldaNES.Weapons.Classes.Fire.States
{
    public class FireTerminationState : IWeaponState
    {
        private Fire fire;
        private ISprite sprite;
        private int lingerCounter;

        public FireTerminationState(Fire fire)
        {
            this.fire = fire;
            sprite = new FireSprite(fire);
            lingerCounter = 0;
        }
        public void Update()
        {
            sprite.Update();
            lingerCounter++;

            if(lingerCounter == WeaponConstants.FireLingerDuration)
            {
                fire.ShouldDelete = true;
            }
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {

        }
    }
}
