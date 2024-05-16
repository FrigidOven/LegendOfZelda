using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeldaNES.Sprites.Classes.LinkSprites;
using ZeldaNES.Sprites;
using ZeldaNES.Game_Constants;
using Microsoft.Xna.Framework.Graphics;
using ZeldaNES.Factories;

namespace ZeldaNES.Players.Link.Classes.States
{
    public class LinkUsingWeaponLeftState : ILinkState
    {
        private Link link;
        private ISprite sprite;
        public LinkUsingWeaponLeftState(Link link)
        {
            this.link = link;
            this.link.Orientation = GeneralConstants.Orientation.Left;
            this.sprite = new LinkUsingWeaponLeftSprite(this.link);
        }
        public void Update()
        {
            sprite.Update();
        }
        public void Draw()
        {
            sprite.Draw();
        }
        public void Stop()
        {
            this.link.SetState(new LinkStoppedLeftState(this.link));
        }
        public void WalkUp()
        {
            this.link.SetState(new LinkStoppedUpState(this.link));
        }
        public void WalkDown()
        {
            this.link.SetState(new LinkStoppedDownState(this.link));
        }
        public void WalkLeft()
        {
            this.link.SetState(new LinkStoppedLeftState(this.link));
        }
        public void WalkRight()
        {
            this.link.SetState(new LinkStoppedRightState(this.link));
        }
        public void SwingSword()
        {
            this.link.SetState(new LinkSwingingSwordLeftState(this.link));
        }
        public void UseWeapon()
        {
            // do nothing, already used weapon
        }
        public void Dash()
        {
            link.SetState(new LinkDashState(this.link));
        }
        public void PickUpSmall()
        {

        }
        public void PickUpLarge()
        {

        }
        public void KnockBack(int distance)
        {

        }
        public void Death()
        {
            link.SetState(new LinkDeathState(this.link));
        }
    }
}
