using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Players.Link;
using ZeldaNES.Sprites;
using ZeldaNES.Weapons.Classes.MetalBoomerang.States;

namespace ZeldaNES.Weapons.Classes.MetalBoomerang.States
{
    public class MetalBoomerangReturningState : IWeaponState
    {
        private MetalBoomerang metalBoomerang;
        private ISprite sprite;

        private Vector2 ownerDirection;

        private IWeaponUser owner;

        public MetalBoomerangReturningState(MetalBoomerang metalBoomerang, ISprite sprite, IWeaponUser owner)
        {
            this.metalBoomerang = metalBoomerang;
            this.owner = owner;
            this.sprite = sprite;

            ownerDirection = new Vector2();
            ownerDirection.X = owner.PosX - metalBoomerang.PosX;
            ownerDirection.Y = owner.PosY - metalBoomerang.PosY;

            ownerDirection.Normalize();
            ownerDirection = Vector2.Multiply(ownerDirection, (float)WeaponConstants.MetalBoomerangSpeed);
        }
        public void Update()
        {
            int newPosX = (int)(metalBoomerang.PosX + ownerDirection.X);
            int newPosY = (int)(metalBoomerang.PosY + ownerDirection.Y);

            metalBoomerang.PosX = newPosX;
            metalBoomerang.PosY = newPosY;

            sprite.Update();
            AdjustOwnerDirection();
        }
        private void AdjustOwnerDirection()
        {
            ownerDirection = new Vector2();
            ownerDirection.X = owner.PosX - metalBoomerang.PosX;
            ownerDirection.Y = owner.PosY - metalBoomerang.PosY;

            ownerDirection.Normalize();
            ownerDirection = Vector2.Multiply(ownerDirection, (float)WeaponConstants.MetalBoomerangSpeed);
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            if (owner is ILink)
            {
                
            }
        }
    }
}
