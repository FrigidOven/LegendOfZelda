using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.WeaponSprites.MetalArrow;
using ZeldaNES.Sprites;

namespace ZeldaNES.Weapons.Classes.MetalArrow.States
{
    public class MetalArrowGoingDownState : IWeaponState
    {
        private MetalArrow metalArrow;
        private ISprite sprite;

        public MetalArrowGoingDownState(MetalArrow metalArrow)
        {
            this.metalArrow = metalArrow;
            sprite = new MetalArrowGoingDownSprite(metalArrow);
        }
        public void Update()
        {
            sprite.Update();
            metalArrow.PosY = metalArrow.PosY + WeaponConstants.MetalArrowSpeed;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            metalArrow.state = new MetalArrowTerminationState(metalArrow);
        }
    }
}
