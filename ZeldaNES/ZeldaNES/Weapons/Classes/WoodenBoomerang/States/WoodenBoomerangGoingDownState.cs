using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.WeaponSprites.WoodenBoomerang;
using ZeldaNES.Sprites;
using ZeldaNES.Weapons.Classes.WoodenBoomerang.States;
using ZeldaNES.Players.Link;
using ZeldaNES.Weapons.Classes.MetalBoomerang.States;
using ZeldaNES.Weapons.Classes.MetalBoomerang;

namespace ZeldaNES.Weapons.Classes.WoodenBoomerang.States
{
    public class WoodenBoomerangGoingDownState : IWeaponState
    {
        private WoodenBoomerang woodenBoomerang;
        private ISprite sprite;

        private IWeaponUser owner;

        public WoodenBoomerangGoingDownState(WoodenBoomerang woodenBoomerang, IWeaponUser owner)
        {
            this.owner = owner;
            this.woodenBoomerang = woodenBoomerang;
            sprite = new WoodenBoomerangGoingDownSprite(woodenBoomerang);
        }
        public void Update()
        {
            sprite.Update();
            woodenBoomerang.PosY = woodenBoomerang.PosY + WeaponConstants.WoodenBoomerangSpeed;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            woodenBoomerang.state = new WoodenBoomerangReturningState(woodenBoomerang, sprite, owner);
        }
    }
}
