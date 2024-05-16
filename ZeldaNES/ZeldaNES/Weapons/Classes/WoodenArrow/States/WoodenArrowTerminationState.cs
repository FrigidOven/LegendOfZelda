using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.WeaponSprites.WoodenArrow;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.WeaponSprites.Termination;

namespace ZeldaNES.Weapons.Classes.WoodenArrow.States
{
    public class WoodenArrowTerminationState : IWeaponState
    {
        private WoodenArrow woodenArrow;
        private ISprite sprite;

        public WoodenArrowTerminationState(WoodenArrow woodenArrow)
        {
            this.woodenArrow = woodenArrow;
            sprite = new ArrowTerminationSprite(woodenArrow);
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
            
        }
    }
}
