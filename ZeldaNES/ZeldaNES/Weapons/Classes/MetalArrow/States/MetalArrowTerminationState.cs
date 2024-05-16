using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.WeaponSprites.MetalArrow;
using ZeldaNES.Sprites;
using ZeldaNES.Sprites.Classes.WeaponSprites.Termination;

namespace ZeldaNES.Weapons.Classes.MetalArrow.States
{
    public class MetalArrowTerminationState : IWeaponState
    {
        private MetalArrow metalArrow;
        private ISprite sprite;

        public MetalArrowTerminationState(MetalArrow metalArrow)
        {
            this.metalArrow = metalArrow;
            sprite = new ArrowTerminationSprite(metalArrow);
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
