using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;
using ZeldaNES.Sprites;

namespace ZeldaNES.Weapons.Classes.WoodenBoomerang.States
{
    public class WoodenBoomerangReturningState : IWeaponState
    {
        private WoodenBoomerang woodenBoomerang;
        private ISprite sprite;

        private Vector2 ownerDirection;

        private IWeaponUser owner;

        public WoodenBoomerangReturningState(WoodenBoomerang woodenBoomerang, ISprite sprite, IWeaponUser owner)
        {
            this.woodenBoomerang = woodenBoomerang;
            this.owner = owner;
            this.sprite = sprite;

            ownerDirection = new Vector2();
            ownerDirection.X = owner.PosX - woodenBoomerang.PosX;
            ownerDirection.Y = owner.PosY - woodenBoomerang.PosY;

            ownerDirection.Normalize();
            ownerDirection = Vector2.Multiply(ownerDirection, (float) WeaponConstants.WoodenBoomerangSpeed);
        }
        public void Update()
        {
            int newPosX = (int) (woodenBoomerang.PosX + ownerDirection.X);
            int newPosY = (int) (woodenBoomerang.PosY + ownerDirection.Y);

            woodenBoomerang.PosX = newPosX;
            woodenBoomerang.PosY = newPosY;

            sprite.Update();
            AdjustOwnerDirection();
        }
        private void AdjustOwnerDirection()
        {
            ownerDirection = new Vector2();

            ownerDirection.X = owner.PosX - woodenBoomerang.PosX;
            ownerDirection.Y = owner.PosY - woodenBoomerang.PosY;

            ownerDirection.Normalize();
            ownerDirection = Vector2.Multiply(ownerDirection, (float)WeaponConstants.WoodenBoomerangSpeed);
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
