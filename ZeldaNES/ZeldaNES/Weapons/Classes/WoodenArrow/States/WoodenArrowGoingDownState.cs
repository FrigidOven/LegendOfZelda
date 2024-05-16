using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.WeaponSprites.WoodenArrow;

namespace ZeldaNES.Weapons.Classes.WoodenArrow.States
{
    public class WoodenArrowGoingDownState : IWeaponState
    {
        private WoodenArrow woodenArrow;
        private ISprite sprite;

        public WoodenArrowGoingDownState(WoodenArrow woodenArrow)
        {
            this.woodenArrow = woodenArrow;
            sprite = new WoodenArrowGoingDownSprite(woodenArrow);
        }
        public void Update()
        {
            sprite.Update();
            woodenArrow.PosY = woodenArrow.PosY + WeaponConstants.WoodenArrowSpeed;
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
