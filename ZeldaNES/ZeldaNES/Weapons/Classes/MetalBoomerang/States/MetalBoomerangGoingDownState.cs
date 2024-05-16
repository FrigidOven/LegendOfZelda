using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Game_Constants;
using ZeldaNES.Sprites.Classes.WeaponSprites.MetalBoomerang;
using ZeldaNES.Sprites;
using ZeldaNES.Weapons.Classes.MetalBoomerang.States;
using ZeldaNES.Players.Link;

namespace ZeldaNES.Weapons.Classes.MetalBoomerang.States
{
    public class MetalBoomerangGoingDownState : IWeaponState
    {
        private MetalBoomerang metalBoomerang;
        private ISprite sprite;
        private IWeaponUser owner;

        public MetalBoomerangGoingDownState(MetalBoomerang metalBoomerang, IWeaponUser owner)
        {
            this.metalBoomerang = metalBoomerang;
            this.owner = owner;
            sprite = new MetalBoomerangGoingDownSprite(metalBoomerang);
        }
        public void Update()
        {
            sprite.Update();
            metalBoomerang.PosY = metalBoomerang.PosY + WeaponConstants.MetalBoomerangSpeed;
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Terminate()
        {
            metalBoomerang.state = new MetalBoomerangReturningState(metalBoomerang, sprite, owner);
        }
    }
}
