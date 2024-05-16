﻿using Microsoft.Xna.Framework.Graphics;
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

namespace ZeldaNES.Weapons.Classes.WoodenBoomerang.States
{
    public class WoodenBoomerangGoingUpState : IWeaponState
    {
        private WoodenBoomerang woodenBoomerang;
        private ISprite sprite;

        private IWeaponUser owner;

        public WoodenBoomerangGoingUpState(WoodenBoomerang woodenBoomerang, IWeaponUser owner)
        {
            this.owner = owner;
            this.woodenBoomerang = woodenBoomerang;
            sprite = new WoodenBoomerangGoingUpSprite(woodenBoomerang);
        }
        public void Update()
        {
            sprite.Update();
            woodenBoomerang.PosY = woodenBoomerang.PosY - WeaponConstants.WoodenBoomerangSpeed;
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
