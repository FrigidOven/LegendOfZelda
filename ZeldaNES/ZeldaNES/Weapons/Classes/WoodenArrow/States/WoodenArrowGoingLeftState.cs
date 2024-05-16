using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.WeaponSprites.WoodenArrow;
using ZeldaNES.Sprites;

namespace ZeldaNES.Weapons.Classes.WoodenArrow.States
{
    public class WoodenArrowGoingLeftState : IWeaponState
    {
        private WoodenArrow woodenArrow;
        private ISprite sprite;

        public WoodenArrowGoingLeftState(WoodenArrow woodenArrow)
        {
            this.woodenArrow = woodenArrow;
            sprite = new WoodenArrowGoingLeftSprite(woodenArrow);
        }
        public void Update()
        {
            sprite.Update();
            woodenArrow.PosX = woodenArrow.PosX - WeaponConstants.WoodenArrowSpeed;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            woodenArrow.state = new WoodenArrowTerminationState(woodenArrow);
        }
    }
}
